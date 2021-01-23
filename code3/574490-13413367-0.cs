        public DispatcherOperation BeginInvoke(DispatcherPriority priority, Delegate method)
        {
            return this.LegacyBeginInvokeImpl(priority, method, null, 0);
        }
        private DispatcherOperation LegacyBeginInvokeImpl(DispatcherPriority priority, Delegate method, object args, int numArgs)
        {
            Dispatcher.ValidatePriority(priority, "priority");
            if (method == null)
            {
                throw new ArgumentNullException("method");
            }
            DispatcherOperation dispatcherOperation = new DispatcherOperation(this, method, priority, args, numArgs);
            this.InvokeAsyncImpl(dispatcherOperation, CancellationToken.None);
            return dispatcherOperation;
        }
