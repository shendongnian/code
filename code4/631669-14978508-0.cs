    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (...){
                //hide controls
                foreach (Control c in e.Row.Controls)
	            {
		             c.Visible=false;
	            }
                //change color
                e.Row.Style.Add("background-color","red");
            }
        }
