	void GridViewSim_RowDeleted(Object sender, GridViewDeletedEventArgs e)
	{
		if(e.Exception == null)
		{
			//Delete was successful - Do Something
		}
		else
		{
		  // Delete was not successful - Do something else
		  e.ExceptionHandled = true;   
		}
	}
