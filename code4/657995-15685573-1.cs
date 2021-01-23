    protected string conS = "Data Source=.\\SQLEXPRESS;AttachDbFilename=|DataDirectory|\\Databees.mdf;Integrated Security=True;User Instance=True";
    protected SqlConnection con;
    protected void Page_Load(object sender, EventArgs e)
    {
        con = new SqlConnection(conS);
        try
        {
            con.Open();
            string q = "SELECT * FROM tblKLanten;";
            SqlCommand query = new SqlCommand(q, con);
            using (SqlDataReader dr = query.ExecuteReader())
            {
                bool success = dr.Read();
                if (success)
                {
                    Label1.Text = dr.GetString(1);
                }
            }
            con.Close();
        }
        catch (Exception ex)
        {
            Label2.Text = "Error";
        }
    }
