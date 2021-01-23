    public class SomeBaseClass
    {
      public SomeBaseClass(Func<string> GetSqlQueryText){
        string sqlQueryText = GetSqlQueryText();
        //Initialize(sqlQueryText);
      }
    }
