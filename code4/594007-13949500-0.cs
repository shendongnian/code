    protected string finalValueFromWeb ;
    
    ....
    
    public void Main()
        {
    		...
    		lock(finalValueFromWeb)
    		{
    			MessageBox.Show(finalValueFromWeb);  
    		}
    	}
    	
     public  void findHiddenURL(String refObject)
        {
    		...
    		lock(finalValueFromWeb)
    		{
    			finalValueFromWeb = link.Url;   
    		}
    	}
