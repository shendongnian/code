    bool readerHasRows = false; // <-- Initialize bool here for later use
        
                            string firma= txt_friema.Text;
                            string model= txt_model.Text;
        
                            //string color_na = textBox3.Text;
                            string commandQuery = "SELECT firma,model FROM motociclete WHERE firma = @firma or model=@model";
                            using (SqlCommand cmd = new SqlCommand(commandQuery, con))
                            {
                                cmd.Parameters.AddWithValue("@firma", txt_friema.Text);
                                cmd.Parameters.AddWithValue("@model", txt_model.Text);
        
                                
                                using (SqlDataReader reader = cmd.ExecuteReader())
                                {
                                    // bool initialized above is set here
                                    readerHasRows = (reader != null && reader.HasRows);
                                }
                            }
        
                            if (readerHasRows)
                            {
                               
                                MessageBox.Show("Already Exists!!");
                           
        
                            }
        
                          else
                            {
                               //your insertion qrocedure  
                            }
