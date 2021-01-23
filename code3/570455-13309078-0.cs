		foreach(ListItem litem in CustomerListbox.Items)
 		{
    			if (litem.Selected == True)
    			{
				using(SqlConnection sqlConn = Connection.GetConnection())
				{
					using(SqlCommand sqlCmd = new SqlCommand())
					{
						
						sqlCmd.Connection = sqlConn;
						ListItem li = new ListItem();
                        			li.Value = litem.Value; //Determines position within listbox
                        			li.Text = litem.Text;
                 
                        			sqlCmd.CommandText = "ExportCustomers";
                        			sqlCmd.CommandType = CommandType.StoredProcedure;
                        			sqlCmd.Parameters.AddWithValue("myquery", "insert into CustomerSelect(Customers) values('" + li.Text + "')");
						sqlConn.Open();
                        			sqlCmd.ExecuteNonQuery();
					}
				}
       				
    			}
 		}
        }
