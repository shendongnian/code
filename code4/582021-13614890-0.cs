    StringBuilder sb = new StringBuilder();
           
                    foreach (GridViewRow row in GridView1.Rows)
                    {
                        TextBox tR = row.FindControl("SitUps") as TextBox;
                        if(tR.Text != "")
                        {
                        sb.Append("UPDATE bleaTest SET SitUps = '");
                        sb.Append((row.FindControl("SitUps") as TextBox).Text);
                        sb.Append("'");
                        sb.Append(" WHERE id = ");
                        sb.Append(Convert.ToInt32((row.FindControl("ID") as Label).Text));
                        sb.Append(" ");
                        string connectiongString = "Data Source=WSCJTCSQ1;Initial Catalog=TestDB;Persist Security Info=True;User ID=v2soft;Password=passwordv2soft";
                        SqlConnection myConnection = new SqlConnection(connectiongString);
                        SqlCommand myCommand = new SqlCommand(sb.ToString(), myConnection);
                        myConnection.Open();
                        myCommand.ExecuteNonQuery();
                        myConnection.Close();
                        
                        }
                    }
            BindData();
            }
