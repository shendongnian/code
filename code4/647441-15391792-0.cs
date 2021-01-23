    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["empno"] != null)
            empno = int.Parse(Session["empno"].ToString());
        if (!IsPostBack)
        {
			var ds = AddPoliciesOnEmployees.GetPolicyOnEmployee(empno);
			if (ds.Tables[0].Rows.Count > 0)
			{
				DataRow r = ds.Tables[0].Rows[0];
				Label7.Text = r["policyname"].ToString();
				Label8.Text = r["policyid"].ToString();
				Label9.Text = r["policyamount"].ToString();
				Label10.Text = r["TotalAmount"].ToString();
				Label11.Text = r["pstartdate"].ToString();
			}
		}
	}
