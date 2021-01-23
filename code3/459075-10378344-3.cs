    public interface IMyRepository
    {
       void ChangeEmail(int employeeId, string newEmail);
    }
    public class MyRepository : IMyRepository
    {
       private MyDataContext context;
       public MyRepository(MyDataContext context)
       {
          this.context = context;
       }
       public void ChangeEmail(int employeeId, string newEmail)
       {
          //save your email using your context
       }
    }
