        public override bool OnStart()
        {
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            bool result = base.OnStart();
            Trace.TraceInformation("ReceiverRole has been started");
            
            return result;
        }
        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Trace.TraceError("Unhandled exception in worker role: {0}", e.ExceptionObject);
        }
