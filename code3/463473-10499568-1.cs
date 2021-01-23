    public ActionResult Save(FormCollection form)
    {
    	foreach (var item in form.AllKeys)
    	{
    		string value = form[item];
    		// save data 
    	}
    }
