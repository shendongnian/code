    protected void Page_Load(object sender, EventArgs e)
    {
        int newsDate = -7;
        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["IGSConnectionString1"].ConnectionString))
        {
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM igs_news WHERE DATE(newsDate) = DATEDIFF(day,@newsDays)", conn))
            {
                cmd.Parameters.AddWithValue("@newsDate", newsDate);
                
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataSet ds = new DataSet();
                
                conn.Open();
                da.Fill(ds);
                conn.Close();
                
                newsRepeater.DataSource = ds;
                newsRepeater.DataBind();
            }
        }
    }
