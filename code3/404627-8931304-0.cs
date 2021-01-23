     public string displayUser;
     protected void Page_Load(object sender, EventArgs e)
        {
    
            DirectoryEntry de = GetUser("dramirez");
            if (de != null)
            {
    
                displayUser = de.Properties["displayName"].Value.ToString();
    
                Response.Write(displayUser + "<br/>");
                //Response.Write(de.Properties["telephoneNumber"].Value.ToString() + "<br/>");
                //Response.Write(de.Properties["mail"].Value.ToString() + "<br/>");
                //Response.Write(de.Properties["userPrincipalName"].Value.ToString() + "<br/>");
    
               } 
    
    
    
           }
