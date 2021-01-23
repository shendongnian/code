    public string IDValue;  // If not referenced in the HTML, it should be moved inside the Page_Load method.
    void Page_Load(object sender, System.EventArgs e)
    {
        string incomeData = Request["RequestID"];
        if (incomeData != null && incomeData != "")
        {
            IDValue = incomeData ;
        }
        Response.Write(IDValue);
    }
