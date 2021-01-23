     SqlConnection connection = new SqlConnection
     {
          ConnectionString = ConfigurationManager.ConnectionStrings["Connection_String_Name"].ConnectionString
     };
     
     connection.Open();
     SqlCommand cmd = new SqlCommand("Query_For_What_You_Wanna_Do");
     cmd.ExecuteNonQuery();
            
     connection.Close();
