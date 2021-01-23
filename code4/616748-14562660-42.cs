    public class SimpleInjectorJobFactory : IJobFactory
    {
        private readonly Container container;
        private readonly Dictionary<Type, InstanceProducer> jobProducers;
        public SimpleInjectorJobFactory(
            Container container, params Assembly[] assemblies)
        {
            this.container = container;
            // By creating producers, jobs can be decorated.
            var transient = Lifestyle.Transient;
            this.jobProducers =
                container.GetTypesToRegister(typeof(IJob), assemblies).ToDictionary(
                    type => type,
                    type => transient.CreateProducer(typeof(IJob), type, container));
        }
        public IJob NewJob(TriggerFiredBundle bundle, IScheduler _)
        {
            var jobProducer = this.jobProducers[bundle.JobDetail.JobType];
            return new AsyncScopedJobDecorator(
                this.container, () => (IJob)jobProducer.GetInstance());
        }
        public void ReturnJob(IJob job)
        {
            // This will be handled automatically by Simple Injector
        }
        private sealed class AsyncScopedJobDecorator : IJob
        {
            private readonly Container container;
            private readonly Func<IJob> decorateeFactory;
            public AsyncScopedJobDecorator(
                Container container, Func<IJob> decorateeFactory)
            {
                this.container = container;
                this.decorateeFactory = decorateeFactory;
            }
            public async Task Execute(IJobExecutionContext context)
            {
                using (AsyncScopedLifestyle.BeginScope(this.container))
                {
                    var job = this.decorateeFactory();
                    await job.Execute(context);
                }
            }
        }
    }
