    public class WorkerRole : RoleEntryPoint
    {
        Waiter waiter;
        public override bool OnStart()
        {
            waiter = new Waiter(WorkerConfiguration.WaitInterval);
            return base.OnStart();
        }
        public override void Run()
        {
            while (true)
            {
                DoWork();
                waiter.Wait();
            }
        }
        public void DoWork()
        {
            // [...]
        }
    }
