    // This class implements IDisposable for easy control over DB connection resources.
    // You could also design and implement an IRepository interface depending on your needs.
    public class PersonRepository : IDisposable
    {
       private SqlConnection conn;
    
       public PersonRepository()
       {
          // in here you initialize connection resources
          conn = new SqlConnection("someConnectionString");
       }
    
       public void IDisposable.Dispose()
       {
          // clean up the connection
          conn.Dispose();
       }
    
       // The instance methods talk to the database
       public int SavePerson(string name, string address)
       {
          // call your stored procedure (or whatever) and return the new ID
          using(SqlCommand cmd = conn.CreateCommand())
          {
             // stuff
             return (int)cmd.Parameters["myOutputIDParameter"].Value;
          }
       }
    
       public DataReader GetPerson(int id)
       {
          // call your stored procedure (or whatever) and return the fetched data
          using(SqlCommand cmd = conn.CreateCommand())
          {
             // stuff
             return cmd.ExecuteReader();
          }
       }
    }
