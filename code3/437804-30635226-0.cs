    public class JobScheduler
        {
           public static void Start()
           {
                ISchedulerFactory sf = new StdSchedulerFactory();
                IScheduler sched = sf.GetScheduler();
                DateTime[] Jobtime = new DateTime[5]; //Array Have Job time
                startDate[0] = new DateTime(2015, 6, 3, 16, 57, 0);
                startDate[1] = new DateTime(2015, 6, 3, 16, 59, 0);
                startDate[2] = new DateTime(2015, 6, 3, 17, 1, 0);
                startDate[3] = new DateTime(2015, 6, 3, 17, 4, 0);
                  
                for (int i = 1; i < Jobtime.Count(); i++)
            {
                sched.Start();
               
                string strjob = "job" + i.ToString();
                string strgroup = "group" + i.ToString();
                string strtigger = "trigger" + i.ToString();
                
                IJobDetail job = JobBuilder.Create<EmailJob>()
                    .WithIdentity(strjob, strgroup)
                    .Build();
                ISimpleTrigger trigger = (ISimpleTrigger)TriggerBuilder.Create()
                    
                    .WithIdentity(strtigger, strgroup)
                    .StartAt(Jobtime[i])
                    .Build();
                sched.ScheduleJob(job, trigger);
               
            }
               
           }
        }
