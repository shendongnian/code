    [Serializable]
    public sealed class StateTransitionForbiddenException<T> : InvalidOperationException
        where T : struct
    {
        private readonly T targetState;
        private readonly T state;
        public StateTransitionForbiddenException()
        {
        }
        public StateTransitionForbiddenException(string message)
            : base(message)
        {
        }
        public StateTransitionForbiddenException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
        public StateTransitionForbiddenException(T targetState, T state)
            : base("A transition to state '" + targetState + "' was forbidden by the validate transition callback.")
        {
            this.targetState = targetState;
            this.state = state;
        }
        public StateTransitionForbiddenException(string message, T targetState, T state)
            : base(message)
        {
            this.targetState = targetState;
            this.state = state;
        }
        private StateTransitionForbiddenException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            this.targetState = (T)info.GetValue("TargetState", typeof(T));
            this.state = (T)info.GetValue("State", typeof(T));
        }
        public T TargetState
        {
            get { return this.targetState; }
        }
        public T State
        {
            get { return this.state; }
        }
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("TargetState", this.targetState);
            info.AddValue("State", this.state);
        }
    }
    
    [DebuggerDisplay("{OldState} -> {NewState}")]
    public sealed class StateChangedEventArgs<T> : EventArgs
        where T : struct
    {
        private readonly T oldState;
        private readonly T newState;
        public StateChangedEventArgs(T oldState, T newState)
        {
            this.oldState = oldState;
            this.newState = newState;
        }
        public T OldState
        {
            get { return this.oldState; }
        }
        public T NewState
        {
            get { return this.newState; }
        }
    }
    
    public delegate Task CreateTaskForTransitionCallback(CancellationToken cancellationToken, object state);
    public delegate bool ValidateTransitionCallback<T>(T currentState)
        where T : struct;
    public class StateMachineTaskFactory<T> : TaskFactory
        where T : struct
    {
        private static readonly ExceptionHelper exceptionHelper = new ExceptionHelper(typeof(StateMachineTaskFactory<>));
        private readonly ConcurrentDictionary<T, TransitionRegistrationInfo> transitionRegistrations;
        private readonly object stateSync;
        // the current state
        private T state;
        // the state to which we're currently transitioning
        private T? transitionToState;
        // the task performing the transition
        private Task transitionToTask;
        public StateMachineTaskFactory()
            : this(default(T))
        {
        }
        public StateMachineTaskFactory(T startState)
        {
            this.transitionRegistrations = new ConcurrentDictionary<T, TransitionRegistrationInfo>();
            this.stateSync = new object();
            this.state = startState;
        }
        public event EventHandler<StateChangedEventArgs<T>> StateChanged;
        public T State
        {
            get
            {
                return this.state;
            }
            private set
            {
                if (!EqualityComparer<T>.Default.Equals(this.state, value))
                {
                    var oldState = this.state;
                    this.state = value;
                    this.OnStateChanged(new StateChangedEventArgs<T>(oldState, value));
                }
            }
        }
        public void RegisterTransition(T beginTransitionState, T endTransitionState, CreateTaskForTransitionCallback createTaskCallback)
        {
            createTaskCallback.AssertNotNull("factory");
            var transitionRegistrationInfo = new TransitionRegistrationInfo(beginTransitionState, createTaskCallback);
            var registered = this.transitionRegistrations.TryAdd(endTransitionState, transitionRegistrationInfo);
            exceptionHelper.ResolveAndThrowIf(!registered, "transitionAlreadyRegistered", endTransitionState);
        }
        public Task TransitionTo(T endTransitionState, CancellationToken cancellationToken = default(CancellationToken), ValidateTransitionCallback<T> validateTransitionCallback = null, object state = null)
        {
            lock (this.stateSync)
            {
                if (EqualityComparer<T>.Default.Equals(this.state, endTransitionState))
                {
                    // already in the requested state - nothing to do
                    return TaskUtil.FromResult(true);
                }
                else if (this.transitionToState.HasValue && EqualityComparer<T>.Default.Equals(this.transitionToState.Value, endTransitionState))
                {
                    // already in the process of transitioning to the requested state - return same transition task
                    return this.transitionToTask;
                }
                else if (this.transitionToTask != null)
                {
                    // not in the requested state, but there is an outstanding transition in progress, so come back to this request once it's done
                    return this.transitionToTask.Then(x => this.TransitionTo(endTransitionState, cancellationToken, validateTransitionCallback, state));
                }
                else if (validateTransitionCallback != null && !validateTransitionCallback(this.State))
                {
                    // transition is forbidden, so return a failing task to that affect
                    var taskCompletionSource = new TaskCompletionSource<bool>();
                    var exception = new StateTransitionForbiddenException<T>(endTransitionState, this.State);
                    taskCompletionSource.TrySetException(exception);
                    return taskCompletionSource.Task;
                }
                // else, need to transition to the chosen state
                TransitionRegistrationInfo transitionRegistrationInfo;
                var result = this.transitionRegistrations.TryGetValue(endTransitionState, out transitionRegistrationInfo);
                exceptionHelper.ResolveAndThrowIf(!result, "transitionNotRegistered", endTransitionState);
                var beginTransitionState = transitionRegistrationInfo.BeginTransitionState;
                var task = transitionRegistrationInfo.TaskFactory(cancellationToken, state);
                exceptionHelper.ResolveAndThrowIf(task == null, "taskFactoryReturnedNull", endTransitionState);
                var previousState = this.State;
                this.State = beginTransitionState;
                this.transitionToState = endTransitionState;
                this.transitionToTask = task
                    .ContinueWith(
                        x =>
                            {
                                if (x.IsFaulted || cancellationToken.IsCancellationRequested)
                                {
                                    // faulted or canceled, so roll back to previous state
                                    lock (this.stateSync)
                                    {
                                        this.State = previousState;
                                        this.transitionToState = null;
                                        this.transitionToTask = null;
                                    }
                                    if (x.IsFaulted)
                                    {
                                        throw x.Exception;
                                    }
                                    cancellationToken.ThrowIfCancellationRequested();
                                }
                                else
                                {
                                    // succeeded, so commit to end state
                                    lock (this.stateSync)
                                    {
                                        this.State = endTransitionState;
                                        this.transitionToState = null;
                                        this.transitionToTask = null;
                                    }
                                }
                            });
                return this.transitionToTask;
            }
        }
        protected virtual void OnStateChanged(StateChangedEventArgs<T> e)
        {
            this.StateChanged.Raise(this, e);
        }
        private struct TransitionRegistrationInfo
        {
            private readonly T beginTransitionState;
            private readonly CreateTaskForTransitionCallback taskFactory;
            public TransitionRegistrationInfo(T beginTransitionState, CreateTaskForTransitionCallback taskFactory)
            {
                this.beginTransitionState = beginTransitionState;
                this.taskFactory = taskFactory;
            }
            public T BeginTransitionState
            {
                get { return this.beginTransitionState; }
            }
            public CreateTaskForTransitionCallback TaskFactory
            {
                get { return this.taskFactory; }
            }
        }
    }
