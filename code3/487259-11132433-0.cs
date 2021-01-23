    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.GetLeft.Value = invited.GetInviteCountByWeb().ToString();
            HttpCookie oldCookie = Request.Cookies["Time"];
            if (oldCookie != null)
            {
                if (DateTime.Now.ToString("yyyy-MM-dd") == Convert.ToDateTime(oldCookie.Values["GetTime"]).ToString("yyyy-MM-dd"))
                {
                    this.IsGet.Value = "false";
                }
            }
            else
            {
                HttpCookie newCookie = new HttpCookie("Time");
                newCookie.Values.Add("GetTime", DateTime.Now.Date.ToString("yyyy-MM-dd"));
                newCookie.Expires = DateTime.Now.AddHours(24.0);
                Response.Cookies.Add(newCookie);
            }
        }
