    StringBuilder _strBld = new StringBuilder();
    int _intItemCount = 0;
    
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        System.Net.WebClient myWebClient = new System.Net.WebClient();
        myWebClient.Headers.Add("Charset", "text/html; charset=UTF-8");
        myWebClient.Headers.Add("Content-Type", "application/x-www-form-urlencoded"); // ◄  This line is essential
    
    // Perform server-side validations (same as before)
    if (this.F_Name.Text.Length == 0 || this.L_Name.Text.Length == 0)
    { AppendError("First and Last name must be provided"); }
    …
    
    // Add the user-provided name values
    AppendUploadString("last_name", this.L_Name.Text);
    AppendUploadString ("first_name", this.F_Name.Text);
    AppendUploadString ("address", this.Address.Text);
    
    // Add the Toppings
    foreach (ListItem item in this.ToppingsChkBoxList.Items)
    {
    if (item.Selected)
        {
            AppendUploadString("Toppings", item.Value.ToString());
        }
    }
    
    myWebClient.UploadString("https http://www.Destination.com/...?encoding=UTF-8", "POST", _strBld.ToString());
    }
    
    private void AppendUploadString(string strName, string strValue)
    
    {
        _intItemCount++;
        _strBld.Append((intItemCount == 1 ? "" : "&") + strName + "=" + System.Web.HttpUtility.UrlEncode(strValue));
        // Update: Use UrlEncode to ensure that the special characters are included in the submission
    }
