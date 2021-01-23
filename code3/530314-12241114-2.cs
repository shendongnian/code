     using(SqlConnection openCon=new SqlConnection("your_connection_String"))
        {
          string saveStaff = "INSERT into tbl_staff (staffName,userID,idDepartment) VALUES (@staffName,@userID,@idDepartment)";
            
          using(SqlCommand querySaveStaff = new SqlCommand(saveStaff))
           {
             querySaveStaff.Connection=openCon;
             querySaveStaff.Parameters.Add("@staffName",SqlDbType.VarChar,30).Value=name;
             .....
             openCon.Open();
             
             
           }
         }
