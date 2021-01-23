    public static class Services
    {
        public static JobService JobService { get; private set; }
        public static UserService UserService { get; private set; }
        static Services( )
        {
            JobService = new JobService();
            UserService = new UserService();
            JobService.JobAdded += JobService_JobAdded;
            UserService.UserDeleted += UserService_UserDeleted;
        }
        private static void UserService_UserDeleted(User user)
        {
            JobService.DeleteJobs(user.ID);
        }
        private static void JobService_JobAdded(User user, Job job)
        {
            UserService.UpdateUser(user, job);
        }
    }
