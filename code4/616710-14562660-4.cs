    public class SimpleInjectorJobFactory : IJobFactory
    {
        private readonly Container container;
        public SimpleInjectorJobFactory(Container container)
        {
            this.container = container;
        }
        public IJob NewJob(TriggerFiredBundle bundle)
        {
            try
            {
                JobDetail jobDetail = bundle.JobDetail;
                Type jobType = jobDetail.JobType;
                // Return job registrated in container
                return (IJob)container.GetInstance(jobType);
            }
            catch (Exception ex)
            {
                throw new SchedulerException(
                    "Problem instantiating class", ex);
            }
        }
    }
