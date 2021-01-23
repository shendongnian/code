    protected void Page_Load(object sender, EventArgs e)
    {
        lb1.Text = GetRecordCount(textbox2.Text).ToString();
    }
    private int GetRecordCount(string myParameter)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ToString();
        Int32 count = 0;
        string sql = "SELECT COUNT(*) FROM members WHERE sponsor = @Sponsor";
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@Sponsor", SqlDbType.VarChar);
            cmd.Parameters["@Sponsor"].Value = myParameter;
            try
            {
                conn.Open();
                count = (Int32)cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                
            }
        }
        return (int)count;
    }
