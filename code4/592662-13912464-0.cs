    interface IJob
    {
        void Step1();
        void Step2();
        ...
    }
    
    var step1 = new BlockingCollection<IJob>();
    var step2 = new BlockingCollection<IJob>();
    ...
    Task.Factory.StartNew(() =>
        {
            foreach(var step in step1.GetConsumingEnumerable()) {
                step.Step1();
                step2.Add(step);
            }
        });
    Task.Factory.StartNew(() =>
        {
            foreach(var step in step2.GetConsumingEnumerable()) {
                // while performing Step2, another thread can execute Step1
                // of the next job
                step.Step2();
                step3.Add(step);
            }
        });
