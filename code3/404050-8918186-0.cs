    public class DataBaseNameProvider
    {
       public string GetDataBaseName()
       {
          var userName = Membership.GetUser().UserName;
          return GetDatabaseNameByUserName(userName);
       }
    }
