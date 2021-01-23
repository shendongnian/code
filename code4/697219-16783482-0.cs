        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadGrid();
            }
           
        }
        private void LoadGrid()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source =localhost;" +
                "Initial Catalog = project; Integrated Security = SSPI";
            conn.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("SELECT policeid, password, email, nric, fullname, contact, address, location From LoginRegisterPolice where pending='pending'", conn);
            da.Fill(ds);
            GVVerify.DataSource = ds;
            GVVerify.DataBind();
            conn.Close();
        }
        protected void btnVerify_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=localhost; Initial Catalog=project; Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Update LoginRegisterPolice set pending='approved' where policeid='" + lblOID.Text + "'", con);
            cmd.ExecuteNonQuery();
            lblMsg.Text = "The following officer has been verified.";
            LoadGrid();
        }
