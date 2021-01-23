    public class YourViewModel 
    {
    	public string FirstName { get; set; }
    	public string LastName { get; set; }
        // other fields here as needed.
    
    	public YourViewModel() 
    	{
    		// you can put any field defaults you need here
    	}
    
    	public string InserRecord() 
    	{
    		String dataXml = "<Data>";
    		dataXml += "<firstnamex>" + firstnamex.Text + "</firstnamex>";
    		dataXml += "<lastnamex>" + lastnamex.Text + "</lastnamex>";
    		dataXml += "</Data>";
    		mainApi.Service1 ws = new mainApi.Service1();
    		return ws.InsertRecord(dataXml);
    	}
    }
    
    public class YourController 
    {
    	public ActionResult YourAction() 
    	{
    		var viewModel = new YourViewModel();
    		return View(viewModel);
    	}
    
    	[HttpPost]
    	public ActionResult YourAction(YourViewModel viewModel) 
    	{
    		var resultFromInsert = viewModel.InserRecord();
    		// redirect here based on string returned above, or whatever.
    	}
    }
