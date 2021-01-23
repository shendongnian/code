    //here is your MainForm
    {
    	public List<MyGVContent> SetColumnHead
    	{
    		   set
    		   {
    				  //here call your method to whom give 'value' as parameter
    				  //attention, that in value contains items with Type, Title, Time
    				  addRowToDataGridView();
    		   }
    	}
    	//which will update your 'dgvTasks' gridview
    ) 
    
    //here is your Parameters Form
    {
    	private void btnSave_Click(object sender, EventArgs e)
    	{
    		//here call the property to whom send parameters
    		this.MainForm.SetColumnHead = ...
    	}
    }
    
    //where 
    public sealed class MyGVContent
    {
    	string Type
    	{
    		get; set;
    	}
    		   
    	string Title
    	{
    		get; set;
    	}
    
    	string Time
    	{
    		get; set;
    	}
    }
