    .property instance string Source()
    {
    	.get instance string System.Exception::get_Source()
    	.set instance void System.Exception::set_Source(string)
    }
    
    .method public hidebysig specialname newslot virtual 
    	instance string get_Source () cil managed 
    {
        ...
    }
    
    .method public hidebysig specialname newslot virtual 
    	instance void set_Source (
    		string 'value'
    	) cil managed 
    {
        ...
    }
