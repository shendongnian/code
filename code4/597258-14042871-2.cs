    public class JobService {
      private UserService us;
      
      public JobService (UserService us) {
        this.us = us;
      }
      
      public void addJob(Job job) {
        // needs to make a call to user service to update some user info
      }
    }
    
    public class UserService {
      private JobService js;
      public UserService(Func<JobService> jsFactory) {
        this.js = jsFactory(this);
      }
      public void deleteUser(User u) {
        // needs to call the job service to delete all the user's jobs
      }
    }        
