    class Integrator
    {
        private JobService _jobService;
        private UserService _userService;
        public void Integrate( )
        {
            _jobService = new JobService();
            _userService = new UserService();
            _jobService.JobAdded += JobService_JobAdded;
            _userService.UserDeleted += UserService_UserDeleted;
        }
        void UserService_UserDeleted(User user)
        {
            _jobService.DeleteJobs(user.ID);
        }
        void JobService_JobAdded(User user, Job job)
        {
            _userService.UpdateUser(user, job);
        }
    }
