        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Text;
        using System.Threading.Tasks;
        using Quartz;
        using Quartz.Impl;
        using Quartz.Job;
        using System.Windows;
        namespace WindowsTrainingTasks
        {
            public partial class Schedulerexample : Window
            {
                public Schedulerexample()
                {
                    InitializeComponent();
                    ISchedulerFactory schedFact = new StdSchedulerFactory();
                    IScheduler quartzScheduler = schedFact.GetScheduler();
                    IJobDetail job = JobBuilder.Create<HelloJob>()
                       .WithIdentity("HelloJob", "group1")
                       .Build();
                    ITrigger trigger = TriggerBuilder.Create()
                    .WithIdentity("DAMMetadataSyncTrigger")
                    .StartNow()
                    .WithSimpleSchedule(x => x
                    .WithIntervalInSeconds(5)
                    .RepeatForever())
                    .Build();
                    quartzScheduler.ScheduleJob(job, trigger);
                    quartzScheduler.Start();
                }
            }
            public class HelloJob : IJob
            {
                public void Execute(IJobExecutionContext context)
                {
                   MessageBox.Show("Xenovex Technologies", "Xenovex5");
                }
            }
        }
