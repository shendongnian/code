    // In Login Page ..
    // I used a submit button to figure out the event of my code ..
    protected void ButtonInsert_Click(object sender, EventArgs e)
    {
        Session.Add("EmployeeID", 100); // This 100 is just a fixed value ..
        if (!String.IsNullOrEmpty(Request.QueryString["Red_Page"]))
        {
            Response.Redirect(Request.QueryString["Red_Page"]);
        }
        else
        {
            Response.Redirect("EmployeeDepartment.aspx");
        }
    }
    // In Master Page ..
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            // In Master Page 
            if (Session["EmployeeID"] != null)
            {
                // Write ur business Code 
            }
            else
            {
                // I stored the Page URL in uery String.
                // Stroing the URL in a cookie will be also a good alternative solution ..
                string CurrentURLBeofreTimeout = Request.RawUrl;
                string LoginURL = "login.aspx";
                string newURL = string.Format("{0}?Red_Page={1}", LoginURL, CurrentURLBeofreTimeout);
                Response.Redirect(newURL);
            }
        }
    }
