    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Quartz;
    using Quartz.Impl;
    
    namespace QuartzNetTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                // construct a scheduler factory
                ISchedulerFactory schedFact = new StdSchedulerFactory();
    
                // get a scheduler
                IScheduler sched = schedFact.GetScheduler();
                sched.Start();
    
                // construct job info
                IJobDetail jobDetail = JobBuilder.Create<HelloJob>()
                    .WithIdentity("myJob")
                    .Build();
                ITrigger trigger = TriggerBuilder.Create()
                    .WithIdentity("myTrigger")
                    // fire every hour
                    .WithSimpleSchedule(x => x.WithIntervalInHours(1).RepeatForever())
                    // start on the next even hour
                    .StartAt(DateBuilder.FutureDate(1, IntervalUnit.Hour))
                    .Build();
    
                sched.ScheduleJob(jobDetail, trigger);
            }
        }
    
        class HelloJob : Quartz.IJob
        {
            public void Execute(IJobExecutionContext context)
            {
                throw new NotImplementedException();
            }
        }
    
    }
