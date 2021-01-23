     public class ConClass
    {
       public SqlConnection Connection()
       {
           SqlConnection con = new SqlConnection(@"Data Source=AHM-0149043-D;Integrated Security=True");
           return con;
       }
    }
