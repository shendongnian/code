    public class DataClass
    {
      public static bool AddEmp(string id, string name)
       {
         bool result;
         OleDbCommand cmd = new OleDbCommand();
         cmd.CommandType = CommandType.Text;
         cmd.CommandText = "INSERT INTO Table1 (ID, Name)";
         cmd.Parameters.AddWithValue("@ID", id);
         cmd.Parameters.AddWithValue("@name", name);
         cmd.Connection=myCon;   
         
         try
          {
            myCon.Open();
            cmd.ExecuteNonQuery();
            result = true;
          }
         catch
          {
             result = false;
          }
    
      myCon.Close();
      return result;  
    }
