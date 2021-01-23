    	if (atddroplist.SelectedIndex  == 1)
            	{
                  empatdListBI c = new empatdListBI();
      	  DbConnection b = new DbConnection();
      	  SqlDataAdapter da = new SqlDataAdapter();
                   DataTable DT = new DataTable();
                   DT = c.LoadRecords(empText.Text);
	  b.OpenConnection();
                   if (DT.Rows.Count == 0)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "PopUp", "alert(' Record Not Found...');", true);
                        txtsearchrecord.Text = "";
                        txtsearchrecord.Focus();
                    }
                    else
                    {
                        GridView1.DataSource = DT;
                        GridView1.DataBind();                    
                    }  
	     b.CloseConnection();                 
                }
            
 
