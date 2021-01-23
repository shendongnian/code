        protected override void OnStart(string[] args)
        {
            (new Thread(() => DoLongRunningStartupWork()){IsBackground = true})
               .Start();
            
        }
        void DoLongRunningStartupWork()
        {
            //actual startup code
        }
