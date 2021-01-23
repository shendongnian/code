    public interface IService() 
    { 
      string GetConnectionString(); 
      void DoStuff(); 
    }
    
    public class DBServiceOne : DbContext, IService
    {
      protected string GetConnectionString() 
      {
        return ConfigurationManager.AppSettings["DBServiceOneConnectionString"]
      }
    
      public DBServiceOne(string str) : base(str)
      {
         this.Database.Connection.ConnectionString = GetConnectionString()
      }
       public void DoStuff() { //logic goes here }
    }
    
    public class DBServiceTwo : DbContext, IService
    {
    
        public DBServiceTwo(string str) : base(str)
        {
          this.Database.Connection.ConnectionString = GetConnectionString();
        }
        
    
        protected string GetConnectionString() 
        {
          return ConfigurationManager.AppSettings["DBServiceTwoConnectionString"]
        }
        public void DoStuff() { //logic goes here }
    }
    
    public class DBServiceThree : DbContext, IService
    {
    
       public DBServiceThree(string str) : base(str)
       {
         this.Database.Connection.ConnectionString = GetConnectionString();
       }
    
       protected string GetConnectionString() 
       {
         return ConfigurationManager.AppSettings["DBServiceThreeConnectionString"]
       }
       public void DoStuff() { //logic goes here }
    }
    
