    public interface IEmployeeFromDatabaseToBasicEmployeeModelConverter 
         : IConverter<TheDBType, MyEmployeeModel>
    public class EmployeeFromDatabaseToBasicEmployeeModelConverter :
                                   IEmployeeFromDatabaseToBasicEmployeeModelConverter 
    {
      public MyEmployeeModel Invoke()
      {
         return new MyEmployeeModel{
          // set properties.
         }
      }
    }
