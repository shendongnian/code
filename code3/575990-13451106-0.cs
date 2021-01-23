    string connString = "Data Source=dha00730-pmtq01\\sqlexpress;Initial Catalog=psspdbTest;Integrated Security=True";
            string insertCommand = "INSERT INTO SafetySuggestionsLog (Title, DateSubmitted, Description, Username, TypeID) values(@Title, @DateSubmitted, @Description, @Username,@TypeID)";
            string username = netID;
            int typeID = Convert.ToInt64(DropDownList.SelectedValue);
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(insertCommand, conn))
                {
                    cmd.Parameters.Clear(); 
                    cmd.Parameters.AddWithValue("@Title", txtSubject.Text);
                    cmd.Parameters.AddWithValue("@DateSubmitted", DateTime.Now.ToString());
                    cmd.Parameters.AddWithValue("@Description", txtSuggestion.Text);
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@TypeID",typeID);    
                    cmd.ExecuteNonQuery();
                }
            }
