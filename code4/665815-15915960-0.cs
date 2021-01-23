    public class JobController : BaseJobController, IJobController
    {
        IUser IJobController.User
        {
            get { return User; }
        }
    }
