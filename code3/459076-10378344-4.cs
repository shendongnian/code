    public class MyCommand
    {
       public MyCommand(IMyRepository myRepository)
       ...
       public void ChangeEmail(int employeeId, string newEmail)
       {
          //adding condition just to clarify how to test
          if(this.AllowChangeEmail(employeeId))
          {
             this.myRepository.ChangeEmail(employeeId, newEmail);
          }
          else
          {
             throw new DomainException("this should not happen");
          }
       }
       ...
    }
