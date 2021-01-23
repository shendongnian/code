    public bool IsOutlookInstalled()
    {
        try
        {
            var officeType = Type.GetTypeFromProgID("Outlook.Application");
            if (officeType == null)
            {
                // Outlook is not installed.   
                return false;
            }
            else
            {
                // Outlook is installed.      
                return true;
            }
        }
        catch (System.Exception ex)
        {
            return false;
        }
    }
