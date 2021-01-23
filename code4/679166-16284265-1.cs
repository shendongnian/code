    [System.Web.Services.WebMethod(EnableSession=true)]
    public int GetNumberOfConversions()
    {
       return (int) Session["Conversions"];
    }
