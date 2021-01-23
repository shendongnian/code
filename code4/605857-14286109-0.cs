    sqlCommand = new SqlCommand("INSERT INTO Department (Description, Comments, Permissions, Active, Production) VALUES (@description, @comments, @permissions, @active, @production)", sqlConnection);
    
                    sqlCommand.Parameters.AddWithValue("@description", txtDescription.Text);
                    sqlCommand.Parameters.AddWithValue("@comments", txtComments.Text);
                    sqlCommand.Parameters.AddWithValue("@permissions", txtPermissions.Text);
                    sqlCommand.Parameters.AddWithValue("@active", Convert.ToString(Convert.ToUInt32(chkActif.Checked)));
                    sqlCommand.Parameters.AddWithValue("@production", Convert.ToString(Convert.ToUInt32(chkProduction.Checked)));
                    sqlCommand.ExecuteNonQuery();
