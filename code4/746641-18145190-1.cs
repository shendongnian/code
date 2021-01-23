       public List<LinkButton> allControlsLinkButtonSalles
       {
    	   get
    	   {
    		   if(Session["allControlsLinkButtonSalles"] == null)
    			   Session["allControlsLinkButtonSalles"] = new List<LinkButton>();
    		   return (List<LinkButton>) Session["allControlsLinkButtonSalles"];
    
    	   }
    	   set
    	   {
    		   Session["allControlsLinkButtonSalles"] = value;
    	   }
       }
