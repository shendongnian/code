    protected void Button2_Click(object sender, EventArgs e)
    {
        using(var con = new SqlConnection(constring))
    	using(var cmd = con.CreateCommand())
    	{
    	    if (DropDownList3.SelectedItem.Text == "Economy")
    		{
    			seats = Convert.ToInt32(DropDownList1.SelectedItem.Text);
    			
    			con.Open();
    			cmd.CommandText = "select easeats from flight where fno='" + fn + "'";
    			
    			int eds = 0;
    			object result = cmd.ExecuteScalar(); 
    			int.TryParse(result, out eds);
    
    			if (eds > seats)
    			{
    				Panel2.Visible = true;                //seats available
    				cl = DropDownList3.SelectedItem.Text;  
    				seat = seats.ToString();
    				seats = eds;
    			}
    			else
    			{
    				Panel3.Visible = true;         // seats not available 
    			}
    		}
    	}
    }
