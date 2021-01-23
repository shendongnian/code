    public interface IEmployeeFromDatabaseToBasicEmployeeModelConverter 
         : IConverter<TheDBType, MyEmployeeModel>{}
    public class EmployeeFromDatabaseToBasicEmployeeModelConverter :
                                   IEmployeeFromDatabaseToBasicEmployeeModelConverter 
    {
      public MyEmployeeModel Invoke(TheDBType myDbTypeObject)
      {
         return new MyEmployeeModel{
          // set properties.
         }
      }
    }
