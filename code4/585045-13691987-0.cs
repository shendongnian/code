    public class WebRole : RoleEntryPoint
    {
        public override bool OnStart()
        {
            Task.Factory.StartNew(StartQuartzJob);
            return base.OnStart();
        }
        private void StartQuartzJob()
        {
            // Do work here.            
        }
    }
