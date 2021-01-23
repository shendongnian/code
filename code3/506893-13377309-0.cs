    public enum ServiceState
    {
        Uninitialized,
        Initializing,
        Initialized,
        Starting,
        Started,
        Stopping,
        Stopped
    }
    public class SomeService
    {
        private readonly StateMachineTaskFactory<ServiceState> stateMachineTaskFactory;
        
        public Service()
        {
            this.stateMachineTaskFactory = new StateMachineTaskFactory<ServiceState>();
            this.stateMachineTaskFactory.RegisterTransition(ServiceState.Initializing, ServiceState.Initialized, this.OnInitializeAsync);
            this.stateMachineTaskFactory.RegisterTransition(ServiceState.Starting, ServiceState.Started, this.OnStartAsync);
            this.stateMachineTaskFactory.RegisterTransition(ServiceState.Stopping, ServiceState.Stopped, this.OnStopAsync);
        }
        
        // we don't support cancellation in our initialize API
        public Task InitializeAsync()
        {
            return this.stateMachineTaskFactory.TransitionTo(ServiceState.Initialized);
        }
        
        public Task StartAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.stateMachineTaskFactory.TransitionTo(ServiceState.Started, cancellationToken);
        }
        
        public Task StopAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.stateMachineTaskFactory.TransitionTo(ServiceState.Stopped, cancellationToken);
        }
        
        // even though we don't support cancellation during initialization, we'll still get a cancellation token, but it will CancellationToken.None
        private Task OnInitializeAsync(CancellationToken cancellationToken, object state)
        {
            // return a Task that performs the actual work involved in initializing
        }
        
        private Task OnStartAsync(CancellationToken cancellationToken, object state)
        {
            // return a Task that performs the actual work involved in starting, passing on the cancellation token as relevant
        }
        
        private Task OnStopAsync(CancellationToken cancellationToken, object state)
        {
            // return a Task that performs the actual work involved in stopping, passing on the cancellation token as relevant
        }
    }
