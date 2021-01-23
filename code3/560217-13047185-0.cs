    /// <summary>
    /// creates a javascript alert in the browser window.
    /// </summary>
    /// <param name="message">The message you wish the user to see in the alert.</param>
    public void AMessage(string message)
    {
        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "info only", "alert('" + message + "');", true);
    }
