    //this is the usercontrol (ascx.cs page):
    	public delegate void EditClientDelegate(string num); 
    	public event EditClientDelegate EditClientEvent; 
    	//call the delegate somewhere in your usercontrol:
    	protected void Page_Load(object sender, System.EventArgs e)
    	{
        	if (EditClientEvent != null) { 
                EditClientEvent("I am raised"); 
            }
    	} 
