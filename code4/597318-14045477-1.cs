    public bool ChangePassword(string empCode, string newPassword, string oldPassword)
    {
        string connectionString = "@<Enter your Connection String Here>";
        string sql = "UPDATE [Employee] SET Pwd=@newpass where EmployeeCode=@empcode";
        if (oldPassword != newPassword)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        conn.Open();
                        cmd.Parameters.AddWithValue("@newpass", newPassword);
                        cmd.Parameters.AddWithValue("@empcode", empCode);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("{0}-{1}", ex.Message, ex.InnerException));
                return false;
            }
            return true;
        }
        else
        {
            MessageBox.Show(string.Format("Your New password {0}, can not be the same as the old password {1}. Please try again.", newPassword, oldPassword));
            return false;
        }
    }
