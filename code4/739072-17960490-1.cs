    protected void upnl_Load(object sender, EventArgs e)
    {
        string eventTarget = (this.Request["__EVENTTARGET"] == null) ? string.Empty : this.Request["__EVENTTARGET"];
        if (string.IsNullOrEmpty(eventTarget)) return;
        var arg = Request.Params.Get("__EVENTARGUMENT");
        if (arg == null) return;
        if (!string.IsNullOrEmpty(arg.ToString()))
        {
            if (arg.ToString().IndexOf("InUse") > -1)
            {
                //Call C# funtion for in use.
            }
            if (arg.ToString().IndexOf("NotInUse") > -1)
            {
                //Call C# funtion for not in use.
            }
        }
    }
    [WebMethod]
    public static string TestIP()
    {
        //Check for IP status
        if (true)
            return "1";
        //else
        //return "0";
    }
