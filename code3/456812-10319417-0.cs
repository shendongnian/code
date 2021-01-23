string strCon = @"Data Source=SYSTEM19\SQLEXPRESS;Initial Catalog=TransactionDB;Integrated Security=True";  
    protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SqlConnection cn = new SqlConnection(strCon);
                SqlCommand cmd = new SqlCommand("select * from tblTransaction1", cn);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataSet ds = new DataSet();
                da.Fill(ds);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    txtName.Text = ds.Tables[0].Rows[i]["FirstName"].ToString();
                    txtName1.Text = ds.Tables[0].Rows[i]["LastName"].ToString();
                }
            }
        }
