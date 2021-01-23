        protected void Application_Start()
        {
            /*
             * Include other Application_Start() code...
             */
            //Job Scheduling
            try {
                //Setup the new Scheduler
                var sf = new StdSchedulerFactory();
                var sched = sf.GetScheduler();
                sched.Start();
                //Setup the Job
                var jobDetail = new JobDetailImpl( "myJob", null, typeof( DocCleanup ) );
                //Create 1 week trigger that will go on forever
                var trigger = new SimpleTriggerImpl( "jobTrigger", SimpleTriggerImpl.RepeatIndefinitely, new TimeSpan( 168, 0, 0 ) );
                trigger.StartTimeUtc = DateTimeOffset.Now;
                //Add the job to the scheduler
                sched.ScheduleJob( jobDetail, trigger );
            } catch (Exception ex) { //Implement Exception code... }
        }
