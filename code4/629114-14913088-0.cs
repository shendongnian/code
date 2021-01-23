    class Program
    {
        static void Main(string[] args)
        {
            Test();
        }
        public static void Test()
        {
            ISchedulerFactory schedulerFactory = new StdSchedulerFactory();
            IScheduler scheduler = schedulerFactory.GetScheduler();
            IJobDetail jobDetail = JobBuilder.Create<SatellitePaymentGenerationJob>()
                .WithIdentity("TestJob")
                .Build();
            ITrigger trigger = TriggerBuilder.Create()
                .ForJob(jobDetail)
                .WithCronSchedule("0 45 20 * * ?")
                .WithIdentity("TestTrigger")
                .StartNow()
                .Build();
            scheduler.ScheduleJob(jobDetail, trigger);
            scheduler.Start();
        }
    }
    internal class SatellitePaymentGenerationJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            Console.WriteLine("test");
        }
    }
