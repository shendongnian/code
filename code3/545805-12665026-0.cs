    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtID.Text = Request.QueryString["id"].ToString();
            SqlConnection con = new SqlConnection(strcon);
            string query = "select * from user_st where ID_st = @id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", stid);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            txtName.Text = dr["name"].ToString();
            txtFamily.Text = dr["family"].ToString();
            txtAddress.Text = dr["adres"].ToString();
            txtHomeTel.Text = dr["home_tel"].ToString();
            txtTahsilat.Text = dr["tahsilat"].ToString();
            txtTel.Text = dr["celphone"].ToString();
            txtEmail.Text = dr["email"].ToString();
            txtShoghl.Text = dr["shoghl"].ToString();
            txtAge.Text = dr["age"].ToString();
            txtFadername.Text = dr["fader_name"].ToString();
            txtIDnumber.Text = dr["melli_code"].ToString();
            txtShSh.Text = dr["sh_sh"].ToString();
        }
    } 
