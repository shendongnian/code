    Public abstract class BaseClass
    {
      Public abstract void myFunc() {}
      
      Public void BaseFunc()
      {      
            using (SqlConnection conn = new SqlConnection(this.MyConnectionString))
            {
                conn.Open();
                myFunc();
                ..any other base implementation...
            }
      }
    }
