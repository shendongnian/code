    public sealed class StateMachineTaskFactoryFixture
    {
        #region Supporting Enums
        private enum State
        {
            Undefined,
            Starting,
            Started,
            Stopping,
            Stopped
        }
        #endregion
        [Fact]
        public void default_ctor_uses_default_value_for_start_state()
        {
            var factory = new StateMachineTaskFactory<State>();
            Assert.Equal(State.Undefined, factory.State);
        }
        [Fact]
        public void ctor_can_set_start_state()
        {
            var factory = new StateMachineTaskFactory<State>(State.Stopped);
            Assert.Equal(State.Stopped, factory.State);
        }
        [Fact]
        public void register_transition_throws_if_factory_is_null()
        {
            var factory = new StateMachineTaskFactory<State>();
            Assert.Throws<ArgumentNullException>(() => factory.RegisterTransition(State.Starting, State.Started, null));
        }
        [Fact]
        public void register_transition_throws_if_transition_already_registered()
        {
            var factory = new StateMachineTaskFactory<State>();
            factory.RegisterTransition(State.Starting, State.Started, (ct, o) => TaskUtil.FromResult(true));
            var ex = Assert.Throws<InvalidOperationException>(() => factory.RegisterTransition(State.Starting, State.Started, (ct, o) => TaskUtil.FromResult(true)));
            Assert.Equal("A transition to state 'Started' has already been registered.", ex.Message);
        }
        [Fact]
        public void transition_to_throws_if_no_transition_registered_for_state()
        {
            var factory = new StateMachineTaskFactory<State>();
            var ex = Assert.Throws<InvalidOperationException>(() => factory.TransitionTo(State.Started));
            Assert.Equal("No transition to state 'Started' has been registered.", ex.Message);
        }
        [Fact]
        public void transition_to_throws_if_task_factory_returns_null()
        {
            var factory = new StateMachineTaskFactory<State>();
            factory.RegisterTransition(State.Starting, State.Started, (ct, o) => null);
            var ex = Assert.Throws<InvalidOperationException>(() => factory.TransitionTo(State.Started));
            Assert.Equal("Task factory for end state 'Started' returned null.", ex.Message);
        }
        [Fact]
        public void transition_to_returns_same_task_if_called_multiple_times_whilst_initial_task_is_still_in_progress()
        {
            var factory = new StateMachineTaskFactory<State>();
            factory.RegisterTransition(State.Starting, State.Started, (ct, o) => TaskUtil.Delay(TimeSpan.FromMilliseconds(250)));
            var initialTask = factory.TransitionTo(State.Started);
            Assert.Equal(initialTask, factory.TransitionTo(State.Started));
            Assert.Equal(initialTask, factory.TransitionTo(State.Started));
            Assert.Equal(initialTask, factory.TransitionTo(State.Started));
            Assert.True(initialTask.Wait(TimeSpan.FromSeconds(3)));
        }
        [Fact]
        public void transition_to_returns_completed_task_if_already_in_desired_state()
        {
            var factory = new StateMachineTaskFactory<State>();
            factory.RegisterTransition(State.Starting, State.Started, (ct, o) => TaskUtil.FromResult(true));
            factory.TransitionTo(State.Started).Wait();
            Assert.Equal(TaskStatus.RanToCompletion, factory.TransitionTo(State.Started).Status);
        }
        [Fact]
        public void transition_to_passes_any_state_to_task_creation_function()
        {
            var factory = new StateMachineTaskFactory<State>();
            string receivedState = null;
            factory.RegisterTransition(
                State.Starting,
                State.Started,
                (ct, o) =>
                {
                    receivedState = o as string;
                    return TaskUtil.FromResult(true);
                });
            factory.TransitionTo(State.Started, CancellationToken.None, null, "here is the state").Wait();
            Assert.Equal("here is the state", receivedState);
        }
        [Fact]
        [SuppressMessage("Microsoft.Naming", "CA2204", Justification = "It's not a word - it's a format string!")]
        public void transition_to_ensures_previous_transition_is_first_completed_before_starting_subsequent_transition()
        {
            var factory = new StateMachineTaskFactory<State>();
            factory.RegisterTransition(State.Starting, State.Started, (ct, o) => TaskUtil.Delay(TimeSpan.FromMilliseconds(10)));
            factory.RegisterTransition(State.Stopping, State.Stopped, (ct, o) => TaskUtil.Delay(TimeSpan.FromMilliseconds(10)));
            var startedAt = DateTime.MinValue;
            var stoppedAt = DateTime.MinValue;
            var startedTask = factory.TransitionTo(State.Started).ContinueWith(x => startedAt = DateTime.UtcNow, TaskContinuationOptions.ExecuteSynchronously);
            var stoppedTask = factory.TransitionTo(State.Stopped).ContinueWith(x => stoppedAt = DateTime.UtcNow, TaskContinuationOptions.ExecuteSynchronously);
            Assert.True(Task.WaitAll(new Task[] { startedTask, stoppedTask }, TimeSpan.FromSeconds(3)), "Timed out waiting for tasks to complete.");
            Assert.True(stoppedAt > startedAt, "stoppedAt is " + stoppedAt.Millisecond + " and startedAt is " + startedAt.Millisecond + ", difference is " + (stoppedAt - startedAt).ToString());
        }
        [Fact]
        public void transition_to_can_be_canceled_before_transition_takes_place()
        {
            var factory = new StateMachineTaskFactory<State>();
            var cancellationTokenSource = new CancellationTokenSource();
            factory.RegisterTransition(State.Starting, State.Started, (ct, o) => TaskUtil.FromResult(true));
            cancellationTokenSource.Cancel();
            var startedTask = factory.TransitionTo(State.Started, cancellationTokenSource.Token);
            try
            {
                startedTask.Wait();
                Assert.True(false, "Failed to throw exception.");
            }
            catch (AggregateException ex)
            {
                Assert.Equal(1, ex.InnerExceptions.Count);
                Assert.IsType<OperationCanceledException>(ex.InnerExceptions[0]);
            }
        }
        [Fact]
        public void transition_to_can_be_canceled()
        {
            var factory = new StateMachineTaskFactory<State>();
            var cancellationTokenSource = new CancellationTokenSource();
            factory.RegisterTransition(State.Starting, State.Started, (ct, o) => TaskUtil.FromResult(true));
            factory.RegisterTransition(State.Stopping, State.Stopped, (ct, o) => TaskUtil.Delay(TimeSpan.FromMilliseconds(150)));
            var startedTask = factory.TransitionTo(State.Started, cancellationTokenSource.Token);
            startedTask.ContinueWith(x => cancellationTokenSource.Cancel());
            var stoppedTask = factory.TransitionTo(State.Stopped, cancellationTokenSource.Token);
            startedTask.Wait(TimeSpan.FromSeconds(3));
            try
            {
                stoppedTask.Wait(TimeSpan.FromSeconds(3));
                Assert.True(false, "Failed to throw exception.");
            }
            catch (AggregateException ex)
            {
                Assert.Equal(1, ex.InnerExceptions.Count);
                Assert.IsType<OperationCanceledException>(ex.InnerExceptions[0]);
            }
        }
        [Fact]
        public void transition_to_can_be_forbidden()
        {
            var factory = new StateMachineTaskFactory<State>();
            factory.RegisterTransition(State.Starting, State.Started, (ct, o) => TaskUtil.FromResult(true));
            factory.RegisterTransition(State.Stopping, State.Stopped, (ct, o) => TaskUtil.FromResult(true));
            var startedTask = factory.TransitionTo(State.Started, CancellationToken.None, x => x == State.Undefined);
            var stoppedTask = factory.TransitionTo(State.Stopped, CancellationToken.None, x => x != State.Started);
            startedTask.Wait(TimeSpan.FromSeconds(3));
            try
            {
                stoppedTask.Wait(TimeSpan.FromSeconds(3));
                Assert.True(false, "Failed to throw exception.");
            }
            catch (AggregateException ex)
            {
                Assert.Equal(1, ex.InnerExceptions.Count);
                var ex2 = Assert.IsType<StateTransitionForbiddenException<State>>(ex.InnerExceptions[0]);
                Assert.Equal(State.Stopped, ex2.TargetState);
                Assert.Equal(State.Started, ex2.State);
                Assert.Equal("A transition to state 'Stopped' was forbidden by the validate transition callback.", ex2.Message);
            }
        }
        [Fact]
        public void canceled_transition_reverts_back_to_original_state()
        {
            var factory = new StateMachineTaskFactory<State>();
            var cancellationTokenSource = new CancellationTokenSource();
            factory.RegisterTransition(State.Starting, State.Started, (ct, o) => TaskUtil.FromResult(true));
            factory.RegisterTransition(State.Stopping, State.Stopped, (ct, o) => TaskUtil.Delay(TimeSpan.FromSeconds(3), cancellationTokenSource.Token));
            factory.StateChanged += (s, e) =>
                {
                    if (e.NewState == State.Stopping)
                    {
                        // cancel the stop
                        cancellationTokenSource.Cancel();
                    }
                };
            var startedTask = factory.TransitionTo(State.Started);
            var stoppedTask = factory.TransitionTo(State.Stopped, cancellationTokenSource.Token);
            startedTask.Wait(TimeSpan.FromSeconds(3));
            try
            {
                stoppedTask.Wait(TimeSpan.FromSeconds(3));
                Assert.True(false, "Failed to throw exception.");
            }
            catch (AggregateException ex)
            {
                Assert.Equal(1, ex.InnerExceptions.Count);
                Assert.IsType<OperationCanceledException>(ex.InnerExceptions[0]);
                Assert.Equal(State.Started, factory.State);
            }
        }
        [Fact]
        public void failed_transition_reverts_back_to_original_state()
        {
            var factory = new StateMachineTaskFactory<State>();
            factory.RegisterTransition(State.Starting, State.Started, (ct, o) => TaskUtil.FromResult(true));
            factory.RegisterTransition(State.Stopping, State.Stopped, (ct, o) => { throw new InvalidOperationException("Something went wrong"); });
            var startedTask = factory.TransitionTo(State.Started);
            var stoppedTask = factory.TransitionTo(State.Stopped);
            startedTask.Wait(TimeSpan.FromSeconds(3));
            try
            {
                stoppedTask.Wait(TimeSpan.FromSeconds(3));
                Assert.True(false, "Failed to throw exception.");
            }
            catch (AggregateException ex)
            {
                Assert.Equal(1, ex.InnerExceptions.Count);
                Assert.IsType<InvalidOperationException>(ex.InnerExceptions[0]);
                Assert.Equal(State.Started, factory.State);
            }
        }
        [Fact]
        public void state_change_is_raised_as_state_changes()
        {
            var factory = new StateMachineTaskFactory<State>(State.Stopped);
            factory.RegisterTransition(State.Starting, State.Started, (ct, o) => TaskUtil.FromResult(true));
            factory.RegisterTransition(State.Stopping, State.Stopped, (ct, o) => TaskUtil.FromResult(true));
            var stateChanges = new List<StateChangedEventArgs<State>>();
            factory.StateChanged += (s, e) => stateChanges.Add(e);
            factory.TransitionTo(State.Started).Wait(TimeSpan.FromSeconds(1));
            factory.TransitionTo(State.Stopped).Wait(TimeSpan.FromSeconds(1));
            factory.TransitionTo(State.Started).Wait(TimeSpan.FromSeconds(1));
            factory.TransitionTo(State.Stopped).Wait(TimeSpan.FromSeconds(1));
            Assert.Equal(8, stateChanges.Count);
            Assert.Equal(State.Stopped, stateChanges[0].OldState);
            Assert.Equal(State.Starting, stateChanges[0].NewState);
            Assert.Equal(State.Starting, stateChanges[1].OldState);
            Assert.Equal(State.Started, stateChanges[1].NewState);
            Assert.Equal(State.Started, stateChanges[2].OldState);
            Assert.Equal(State.Stopping, stateChanges[2].NewState);
            Assert.Equal(State.Stopping, stateChanges[3].OldState);
            Assert.Equal(State.Stopped, stateChanges[3].NewState);
            Assert.Equal(State.Stopped, stateChanges[4].OldState);
            Assert.Equal(State.Starting, stateChanges[4].NewState);
            Assert.Equal(State.Starting, stateChanges[5].OldState);
            Assert.Equal(State.Started, stateChanges[5].NewState);
            Assert.Equal(State.Started, stateChanges[6].OldState);
            Assert.Equal(State.Stopping, stateChanges[6].NewState);
            Assert.Equal(State.Stopping, stateChanges[7].OldState);
            Assert.Equal(State.Stopped, stateChanges[7].NewState);
        }
        [Fact]
        public void state_gets_the_current_state()
        {
            var factory = new StateMachineTaskFactory<State>(State.Stopped);
            factory.RegisterTransition(State.Starting, State.Started, (ct, o) => TaskUtil.Delay(TimeSpan.FromMilliseconds(100)));
            factory.RegisterTransition(State.Stopping, State.Stopped, (ct, o) => TaskUtil.Delay(TimeSpan.FromMilliseconds(100)));
            var task = factory.TransitionTo(State.Started);
            Assert.Equal(State.Starting, factory.State);
            task.Wait(TimeSpan.FromSeconds(3));
            Assert.Equal(State.Started, factory.State);
            task = factory.TransitionTo(State.Stopped);
            Assert.Equal(State.Stopping, factory.State);
            task.Wait(TimeSpan.FromSeconds(3));
            Assert.Equal(State.Stopped, factory.State);
        }
    }
