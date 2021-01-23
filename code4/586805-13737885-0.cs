    int userType = 0;
    if (sdrDatanew.HasRows)
    {
    	if (sdrDatanew.Read())
    	{
    		userType = sdrDatanew.GetInt32(0); //something like this
    	}
    }
    
    switch (userType) //something like this
    {
    	case 0:
    		Response.Redirect("Lic_Gen.aspx");
    		break;
    	case 1:
    		Response.Redirect("Cust_Page.aspx");
    		break;
    }
