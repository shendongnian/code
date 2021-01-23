    protected void BindDropDownList1()
    {
     con.ConnectionString = ConfigurationManager.ConnectionStrings["familyConnectionString"].ConnectionString;
     con.Open();
     adp = new SqlDataAdapter("select distinct family_head from family", con);
     DataSet ds = new DataSet();
     adp.Fill(ds, "family");
     con.Close();
     for (int i = 0; i < ds.Tables["family"].Rows.Count; i++)
       DropDownList1.Items.Add(ds.Tables["family"].Rows[i][0].ToString());
    }
        protected override void OnInit(EventArgs e)
        {
           this.BindDropDownList1();
           base.OnInit(e);
        }
