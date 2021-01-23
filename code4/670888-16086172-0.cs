        public void ScheduleJob(string jobName, string groupName, string triggerName, string cron, bool a)
        {            
            // Load the assembly
            AssemblyName assembly = AssemblyName.GetAssemblyName(@"C:\Program Files\Quartz.net\Jobs2.dll");
            System.Reflection.Assembly obj = System.Reflection.Assembly.Load(assembly);
            Type type = obj.GetType("MyJob2");
            if (!(type is IJob))
            {
                // Nothing, because the Job only have one method from IJob
            }
            // Contructor
            ConstructorInfo ctor = type.GetConstructor(new Type[] { });
            
            object loadedObject = ctor.Invoke(new object[] { obj });
            IJob importedObject = (IJob)loadedObject;                       
            JobKey jobKey = new JobKey(jobName, groupName);
            IJobDetail jobDetail = JobBuilder.Create(importedObject.GetType())
                .WithIdentity(jobName, groupName)
                .Build();
            TriggerKey tkey = new TriggerKey(triggerName, groupName);
            ITrigger cronTrigger = TriggerBuilder.Create()
                .WithIdentity(tkey)
                .ForJob(jobDetail)
                .WithCronSchedule(cron)
                .Build();
            AddJob(jobName, groupName, a);
            GetScheduler().ScheduleJob(cronTrigger);
