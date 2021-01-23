     if(dr.Read())
                {
                    if (tbpid.Text.Equals(dr["policeid"].ToString().Trim()) && (tbnric.Text.Equals(dr["nric"].ToString().Trim())))
                    {
    
                        lbmsg.Text = "This police account has already exist. Please verify the details again.";
    
                    }
                    else if (tbpid.Text.Equals(dr["policeid"].ToString()))
                    {
                        lbmsg.Text = "This police ID has already exists. Please generate another Police ID";
                    }
                }
    
                else
                {
     if (tbnric.Text.Equals(dr["nric"].ToString()))
                    {
                        lbmsg.Text  ="This NRIC has already exist. Please ensure that the NRIC is correct";
                    }
    else
    {
    
                    SqlConnection conn = new SqlConnection("Data Source = localhost; Initial Catalog = MajorProject; Integrated Security= SSPI");
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("insert into PoliceAccount(policeid, password, nric, fullname, postedto)  values('" + tbpid.Text.Trim() + "','" + tbpid.Text.Trim() + "','" + tbnric.Text.Trim() + "','" + tbfullname.Text.Trim() + "', '" + ddllocation.SelectedValue + "')", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
    
                    lbmsg.Text = "Congratulations. The police account of ID " + tbpid.Text + " has been successfully added. You may edit the profile via the edit profile tab above";
    
                    tbpid.Text = "";
                    tbnric.Text = "";
                    tbfullname.Text = "";
                    ddllocation.SelectedValue = "Select Location";
    }
    }
