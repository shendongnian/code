    public void SAN()
        {
            cn.Open();
            string sq = "select  Sitealiasname from tbl_Sitemaster where sitename in (select `sitename from tbl_emploeedetails where employeestatus='L' and employeeid='" + Session["EMPID"].ToString() + "') and    status='A' order by Sitealiasname asc";`
            SqlCommand d = new SqlCommand(sq, cn);
            SqlDataReader r;
            r = d.ExecuteReader();
     List<string> sitnames = new  List<string>();
            while (r.Read())
            {
                sitename.Add(r["Sitealiasname"].ToString().Trim());
            }
            cn.Close();
    Session["Sitealiasname"] = sitename
        }
   
     protected void Page_Load(object sender, EventArgs e)
        {
    ///Bind data here
 
    if(Session["Sitealiasname"] != null){
           ddlsite.DataSource = Session["Sitealiasname"].ToList();
           ddlsite.DataBind();
    }
    }
