    SqlCommand sqlCmd = new SqlCommand("UPDATE usr_Table SET description= @description, subject = @subject, text = @text, status = @status WHERE code = @code", connectionString);
    sqlCmd.Parameters.Add(new SqlParameter("description", newDescription));
    sqlCmd.Parameters.Add(new SqlParameter("subject", newSubject));
    sqlCmd.Parameters.Add(new SqlParameter("text", newText));
    sqlCmd.Parameters.Add(new SqlParameter("status", newStatus));
    sqlCmd.Parameters.Add(new SqlParameter("subject", newSubject));
    sqlCmd.Parameters.Add(new SqlParameter("code", newCode));
    sqlCmd.ExecuteNonQuery();
