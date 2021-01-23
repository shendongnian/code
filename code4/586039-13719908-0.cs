        public async override Task Invoke(Action a)
        {
            DispatcherSynchronizationContext dsc = new DispatcherSynchronizationContext(Deployment.Current.Dispatcher);
            await Task.Factory.StartNew(() => { dsc.Send(new SendOrPostCallback(delegate { a.Invoke(); }), null); });
        }
