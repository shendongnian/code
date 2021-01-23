    public class SimpleInjectorJobFactory : IJobFactory
    {
        private readonly Dictionary<Type, InstanceProducer> jobProducers;
        
        public SimpleInjectorJobFactory(Container container, Assembly[] assemblies)
        {
            var types = container.GetTypesToRegister(typeof(IJob), assemblies);
        
            var lifestyle = Lifestyle.Transient;
        
            // By creating producers here by the IJob service type, jobs can be decorated.
            this.jobProducers = (
                from type in types
                let producer = lifestyle.CreateProducer(typeof(IJob), type, container) 
                select new { type, producer })
                .ToDictionary(t => t.type, t => t.producer);                
        }
        
        public IJob NewJob(TriggerFiredBundle bundle)
        {
            if (bundle.JobDetail.ConcurrentExecutionDisallowed)
            {
                return (IJob)_jobProducers[bundle.JobDetail.JobType].GetInstance();
            }
            else
            {
                return null;
            }
        }
    }
