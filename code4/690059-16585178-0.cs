      private SqlConnection conn = your connection string;
        public void Bind_ddlcountry()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("select countryid,country from tblcountry", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            ddlcountry.DataSource = dr;
            ddlcountry.Items.Clear();
            ddlcountry.Items.Add("--Please Select country--");
            ddlcountry.DataTextField = "Country";
            ddlcountry.DataValueField = "CountryId";
            ddlcountry.DataBind();
            conn.Close();
        }
