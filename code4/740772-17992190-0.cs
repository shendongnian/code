     SqlConnection myConnection = new SqlConnection();  
            myConnection.ConnectionString = WebConfigurationManager.ConnectionStrings["NorthwindConnectionString"].ConnectionString;  
            SqlCommand myCommand = new SqlCommand();  
            myCommand.CommandType = CommandType.Text;  
            myCommand.CommandText = "SELECT CategoryID, CategoryName FROM Categories";  
            myCommand.Connection = myConnection;  
            SqlDataReader myReader;  
  
            try  
            {  
                myConnection.Open();  
                myReader = myCommand.ExecuteReader();  
                while (myReader.Read())  
                {  
                    ListItem li = new ListItem();  
                    li.Value = myReader["CategoryID"].ToString();  
                    li.Text = myReader["CategoryName"].ToString();  
                    ListBox1.Items.Add(li);  
                }  
                myReader.Close();  
            }  
            catch (Exception err)  
            {  
                Response.Write("Error: ");  
                Response.Write(err.ToString());  
            }  
            finally  
            {  
                myConnection.Close();  
            }  
