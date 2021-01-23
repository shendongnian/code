    public class JobService
    {
        public event Action<User, Job> JobAdded;
        public void AddJob(User user, Job job)
        {
            //TODO: Add job.
            // Fire event
            if (JobAdded != null) JobAdded(user, job);
        }
        internal void DeleteJobs(int userID)
        {
            //TODO: Delete jobs
        }
    }
    public class UserService
    {
        public event Action<User> UserDeleted;
        public void DeleteUser(User u)
        {
            //TODO: Delete User.
            // Fire event
            if (UserDeleted != null) UserDeleted(u);
        }
        public void UpdateUser(User user, Job job)
        {
            //TODO: Update user
        }
    }
