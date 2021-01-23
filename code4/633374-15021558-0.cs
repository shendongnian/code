    public bool runJQueryCode(string message)
    {
        ScriptManager requestSM = ScriptManager.GetCurrent(Page);
        if (requestSM != null && requestSM.IsInAsyncPostBack)
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), Guid.NewGuid().ToString(), getjQueryCode(message), true);
        }
        else
        {
            Page.ClientScript.RegisterClientScriptBlock(typeof(Page), Guid.NewGuid().ToString(), getjQueryCode(message), true);
        }
        return true;
    }
    private string getjQueryCode(string jsCodetoRun)
    {
        string x = "";
        x += "$(document).ready(function() {";
        x += jsCodetoRun;
        x += " });";
        return x;
    }
