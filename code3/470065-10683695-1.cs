        using(SqlConnection conn = new SqlConnection("connString"))
        {
            string incrementChips = "UPDATE tbl_UserInfo U SET Chips= @param1 where UserName = @param2 AND QuestionID = @param3";
            // no need to use U.Chips or U.UserName, since you do not update in 2 or more table (where can be same fields)
            using(SqlCommand cmd = new SqlCommand(incrementChips, conn))
            {
               //input parameter:
               cmd.Parameters.Add("@param1", SqlDbType.VarChar, 50).Value = "your input string";
               //and condition parameters:
               cmd.Parameters.Add("@param2", SqlDbType.VarChar, 50).Value = "answerby";
               cmd.Parameters.Add("@param3", SqlDbType.VarChar, 50).Value = "queid";
               try
               {
                   conn.Open();
                   cmd.ExecuteNonQuery();
               }
               catch(Exception ex)
               {
                   //show exception to user (if it happens)
               }
           }
       }
