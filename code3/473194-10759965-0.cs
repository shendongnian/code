    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataTable dttbl = new DataTable();
            dttbl.Columns.Add("PKPersonID", System.Type.GetType("System.String"));
            dttbl.Columns.Add("PerosnelName", System.Type.GetType("System.String"));
            dttbl.Columns.Add("FKRequestID", System.Type.GetType("System.String"));
            Session["MyDataTable"] = dttbl;
        }
    }
    protected void btnok_Click(object sender, EventArgs e)
    {
        DataTable t = (DataTable)Session["MyDataTable"];
        DataRow row1 = t.NewRow();
        row1["PKPersonID"] = txtid.Text ;
        row1["PerosnelName"] = txtname.Text;
        row1["FKRequestID"] = Session["FKRequestID"];
        t.Rows.Add(row1);
        Session["MyDataTable"] = t;
        GridView1.DataSource = t;
        GridView1.DataBind();
    }
    protected void btnsave_Click(object sender, EventArgs e)
        {
            DataTable t2 = (DataTable)Session["MyDataTable"];
            SqlConnection con = new SqlConnection("connection_string"
            using (SqlCommand command = con.CreateCommand())
            {
                //Here you are inserting values to tbl_Request
                if (con.State == 0)
                    con.Open();
                command.CommandText = @"INSERT INTO tbl_Request (PKRequestID,RequestCode) VALUES (@PKRequestID,@RequestCode)";
                command.Parameters.AddWithValue("@PKRequestID", Session["PKRequestID"]);
                command.Parameters.AddWithValue("@RequestCode", Session["RequestCode"]);
                command.ExecuteNonQuery();
            }
    
            foreach (DataRow row in t2.Rows)
            {
                //Here you are inserting values to tbl_Personnel
                using (SqlCommand command2 = con.CreateCommand())
                {
                    if (con.State == 0)
                        con.Open();
                    command2.CommandText = @"INSERT INTO tbl_Personnel (PerosnelName, FKRequestID) VALUES ( @PerosnelName, @FKRequestID)";
                    command2.Parameters.AddWithValue("@PerosnelName", txtname.Text);
                    command2.Parameters.AddWithValue("@FKRequestID", Session["PKRequestID"]);
                    command2.ExecuteNonQuery();
                }
            }
        }
