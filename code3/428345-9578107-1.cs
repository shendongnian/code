        public static void deleteRow(string table, string columnName, string IDNumber)
        {
        try
        {
        using (SqlConnection con = new SqlConnection(Global.connectionString))
        {
             con.Open();
             using (SqlCommand command = new SqlCommand("DELETE FROM " + table + " WHERE " + columnName + " = '" + IDNumber+"'", con))
             {
                   command.ExecuteNonQuery();
             }
             con.Close();
        }
        }
        catch (SystemException ex)
           {
           MessageBox.Show(string.Format("An error occurred: {0}", ex.Message));
           }
        }
     }
