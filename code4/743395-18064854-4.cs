    protected void gridviewID_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        int totalyes=0;
        int totalno=0;
		for(int i=0;i<gridviewID.Columns.Count;i++)
		{
			if (e.Row.RowType == DataControlRowType.DataRow)
			{
				//Assuming the column containg yes or no is the third column.
				if( e.Row.Cells[i].Text.ToLower()=="yes")
				{
					totalyes++
				}
				else
				{
					totalno++;	
				}
			}
			else if (e.Row.RowType == DataControlRowType.Footer)
			{
				e.Row.Cells[i].Text="Total Yes: "+ totalyes.ToString() + "Total No: "+totalno.ToString();
			}
		}
    }
