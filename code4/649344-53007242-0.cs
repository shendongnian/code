        internal class ContingentProperties
        {
            // Additional context
 
            internal ExecutionContext m_capturedContext; // The execution context to run the task within, if any.
 
            // Completion fields (exceptions and event)
 
            internal volatile ManualResetEventSlim m_completionEvent; // Lazily created if waiting is required.
            internal volatile TaskExceptionHolder m_exceptionsHolder; // Tracks exceptions, if any have occurred
 
            // Cancellation fields (token, registration, and internally requested)
 
            internal CancellationToken m_cancellationToken; // Task's cancellation token, if it has one
            internal Shared<CancellationTokenRegistration> m_cancellationRegistration; // Task's registration with the cancellation token
            internal volatile int m_internalCancellationRequested; // Its own field because threads legally ---- to set it.
 
            // Parenting fields
 
            // # of active children + 1 (for this task itself).
            // Used for ensuring all children are done before this task can complete
            // The extra count helps prevent the ---- for executing the final state transition
            // (i.e. whether the last child or this task itself should call FinishStageTwo())
            internal volatile int m_completionCountdown = 1;
            // A list of child tasks that threw an exception (TCEs don't count),
            // but haven't yet been waited on by the parent, lazily initialized.
            internal volatile List<Task> m_exceptionalChildren;
 
            /// <summary>
            /// Sets the internal completion event.
            /// </summary>
            internal void SetCompleted()
            {
                var mres = m_completionEvent;
                if (mres != null) mres.Set();
            }
 
            /// <summary>
            /// Checks if we registered a CT callback during construction, and deregisters it. 
            /// This should be called when we know the registration isn't useful anymore. Specifically from Finish() if the task has completed
            /// successfully or with an exception.
            /// </summary>
            internal void DeregisterCancellationCallback()
            {
                if (m_cancellationRegistration != null)
                {
                    // Harden against ODEs thrown from disposing of the CTR.
                    // Since the task has already been put into a final state by the time this
                    // is called, all we can do here is suppress the exception.
                    try { m_cancellationRegistration.Value.Dispose(); }
                    catch (ObjectDisposedException) { }
                    m_cancellationRegistration = null;
                }
            }
        }
