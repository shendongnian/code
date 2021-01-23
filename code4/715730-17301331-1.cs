    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string frameURL = Request.UrlReferrer.ToString() ?? "NO DATA";
            if ((frameURL != null) && (frameURL != "NO DATA"))
            {
                
                Uri frameURI = new Uri(frameURL);
                NameValueCollection queryVars = HttpUtility.ParseQueryString(frameURI.Query);
                //If this is in Orion, we want to change the canceller to standby if it's 97, not 96
                if (queryVars["NetObject"] == "N:97" || queryVars["NetObject"] == "N%3a97")
                {
                    SelectCanceller.SelectedValue = "Standby";
                    primaryStandby = false;
                }
            }   
