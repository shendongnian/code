    public class SimpleInjectorJobFactory : IJobFactory
    {
        private readonly Container jobProducers;
        public SimpleInjectorJobFactory(params Assembly[] assemblies)
        {
            this.jobProducers = (
                from assembly in assemblies
                from type in assembly.GetTypes()
                where typeof(IJob).IsAssignableFrom(type)
                where !type.IsAbstract && !type.IsGenericTypeDefinition
                let producer = Lifestyle.Transient.CreateProducer(
                    typeof(IJob), type, container) 
                select new { type, producer })
                .ToDictionary(t => t.type, t => t.producer);
        }
        public IJob NewJob(TriggerFiredBundle bundle)
        {
            return (IJob) this.jobProducers[bundle.JobDetail.JobType].GetInstance();
        }
    }
