    protected void RadAjaxManager1_Request(object source, Telerik.Web.UI.AjaxRequestEventArgs e)
    {
    	try
    	{
            if (e.Argument.Trim().Length == 0)
            {
                // Show a message when debugging, otherwise return
                return;
            }
            string argument = (e.Argument);
            String[] stringArray = argument.Split('~');
            switch (stringArray[0])
            {
                case "continue":
                    // Continue performing your action or call a specific method
                    ServerSideMethodCall();
                    break;
            }
        }
        catch (Exception ex)
        {
            RadAjaxManager.GetCurrent(this.Page).Alert("Unable to complete operation at this time: " + ex.Message);
        }
    }
