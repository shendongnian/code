    public class SimpleInjectorJobFactory : IJobFactory
    {
        private readonly Dictionary<Type, InstanceProducer> jobProducers;
        public SimpleInjectorJobFactory(Container container, params Assembly[] assemblies)
        {
            this.jobProducers = (
                from assembly in assemblies
                from type in assembly.GetTypes()
                where typeof(IJob).IsAssignableFrom(type)
                where !type.IsAbstract && !type.IsGenericTypeDefinition
                let ctor = container.Options.ConstructorResolutionBehavior
                    .GetConstructor(typeof(IJob), type)
                let typeIsDecorator =
                    ctor.GetParameters().Any(p => p.ParameterType == typeof(IJob))
                let typeIsDecorateeFactory = ctor.GetParameters().Any(p => p.ParameterType == typeof(Func<IJob>))
                where !typeIsDecorator && !typeIsDecorateeFactory
                let producer = Lifestyle.Transient.CreateProducer(
                    typeof(IJob), type, container) 
                select new { type, producer })
                .ToDictionary(t => t.type, t => t.producer);
        }
        public IJob NewJob(TriggerFiredBundle bundle)
        {
            return (IJob)this.jobProducers[bundle.JobDetail.JobType].GetInstance();
        }
    }
