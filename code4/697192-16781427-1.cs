    protected void LoadExceptions()
    {
        if (!Page.IsPostBack)
        {
            Database db = new Database();
            SqlCommand sql = new SqlCommand();
            
            sql.CommandText = "getSobeysNotReceived";
            
            this.grdNotReceived.DataSource = db.GetSprocDR(sql);
            this.grdNotReceived.DataBind();
            
            db.Close();
        }
    }
