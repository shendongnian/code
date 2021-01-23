    public sealed class Data
    {
      private object data; //actual data
      private BaseDataOperations dataOperations; //This class will implement methods
      public void Method1()  //This method is accessible to others but can't be modified
      {
        // manipulate data
      }
      public void Method2()  //This method will be polymorphically performed
      {
          dataOperations.Method2(data);
      }
    }
    public class BaseDataOperations
    {
      public virtual void Method2(object data)  //This method will be polymorphically performed
      {
          //manipulate data
      }
    }
    public class DerivedDataOperations : BaseDataOperations
    {
      public override void Method2(object data)  //This method will be polymorphically performed
      {
          //manipulate data
      }
    }
