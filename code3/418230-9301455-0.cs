    public interface IRepository  
    {    
            IConnectionStringProvider ConnectionStringProvider  {get; set;}
            string ConnectionString { get; } // no set is required 
     }
    public abstract class Repository : IRepository     
       {       
             IConnectionStringProvider ConnectionStringProvider  {get; set;}
             public string ConnectionString 
               { 
                  get 
                     {
                        return ConnectionStringProvider.GetConnectionString(); 
                     }
                }
       }    
