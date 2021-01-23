    using System;
    using Quartz;
    using Quartz.Impl;
    using Quartz.Impl.Triggers;
    // Necessary references:
    // Quartz dll
    // Common.Logging
    // System.Web
    // System.Web.Services
    
    namespace QuartzExample
    {
        class Program
        {
            private static IScheduler _scheduler;
    
            static void Main(string[] args)
            {
                ISchedulerFactory schedulerFactory = new StdSchedulerFactory();
                _scheduler = schedulerFactory.GetScheduler();
                _scheduler.Start();
                Console.WriteLine("Starting Scheduler");
    
                AddJob();
            }
    
            public static void AddJob()
            {
                IMyJob myJob = new MyJob(); //This Constructor needs to be parameterless
                JobDetailImpl jobDetail = new JobDetailImpl("Job1", "Group1", myJob.GetType());
                CronTriggerImpl trigger = new CronTriggerImpl("Trigger1", "Group1", "0 * 8-17 * * ?"); //run every minute between the hours of 8am and 5pm
                _scheduler.ScheduleJob(jobDetail, trigger);
                DateTimeOffset? nextFireTime = trigger.GetNextFireTimeUtc();
                Console.WriteLine("Next Fire Time:" + nextFireTime.Value);
            }
        }
    
        internal class MyJob : IMyJob
        {
            public void Execute(IJobExecutionContext context)
            {
                Console.WriteLine("In MyJob class");
                DoMoreWork();
            }
    
            public void DoMoreWork()
            {
                Console.WriteLine("Do More Work");
            }
        }
    
        internal interface IMyJob : IJob
        {
        }
    }
