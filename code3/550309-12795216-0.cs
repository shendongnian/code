    SqlConnection conn_Kategori = new SqlConnection(WebConfigurationManager.ConnectionStrings["Computer_Klubben_CommunitySiteConnectionString"].ConnectionString);
        //int TraadVaelger = int.Parse(Request.QueryString["id"]);
        string OutputToLabel;
        int TraadVaelger;
        if (!int.TryParse(Request.QueryString["id"], out TraadVaelger))
        {
            //Errorhandling
            Response.Write("No id was givin");
        }
        using (conn_Kategori)
        {
            conn_Kategori.Open();
            SqlCommand OverfoerTraadNavnet = new SqlCommand("SELECT KatNavn FROM KategoriTabel WHERE KategoriID = @KategoriID", conn_Kategori);
            OverfoerTraadNavnet.CommandType = CommandType.Text;
            OverfoerTraadNavnet.Parameters.AddWithValue("@KategoriID", TraadVaelger);
            OutputToLabel = OverfoerTraadNavnet.ExecuteScalar().ToString();
            Stien.Text = OutputToLabel;
            conn_Kategori.Close();
        }
