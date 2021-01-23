    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SAN();
            bind();
           
           
        }
    }
    private void bind()
    {
        ArrayList ar = new ArrayList();
        ar.Add("first");
        ar.Add("Second");
        ar.Add("Third");
        ar.Add("Four");
        ar.Add("Five");
        ar.Add("Six");
        ar.Add("Seven");
        DropDownList1.DataSource = ar;
        DropDownList1.DataBind();
        DropDownList1.SelectedValue = Session["Sitealiasname"].ToString();
    }
    public void SAN()
        {
            cn.Open();
            string sq = "select  Sitealiasname from tbl_Sitemaster where sitename in (select sitename from tbl_emploeedetails where employeestatus='L' and employeeid='" + Session["EMPID"].ToString() + "') and    status='A' order by Sitealiasname asc";
            SqlCommand d = new SqlCommand(sq, cn);
            SqlDataReader r;
            r = d.ExecuteReader();
            while (r.Read())
            {
                Label4.Text = r["Sitealiasname"].ToString().Trim();
                Session["Sitealiasname"] = Label4.Text;//Suppose here session value "first"
            }
            cn.Close();
        }
