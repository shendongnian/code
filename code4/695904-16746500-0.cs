    public class MyDbContext : DbContext
    {
       ...    
       public MyDbContext(string connStringName) :
          base(connStringName)
       {
         ...
