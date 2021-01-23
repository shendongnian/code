    try
    {
    	Response.Redirect("newpage.aspx", true);
    }
    catch (System.Threading.ThreadAbortException)
    {
    	// ignore it
    }
    catch (Exception x)
    {
    
    }
