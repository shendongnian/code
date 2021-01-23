    SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString);
             DataSet ds = new DataSet();
             SqlCommand cmd = new SqlCommand("Select * from country", cn);
             SqlDataAdapter adp = new SqlDataAdapter(cmd);
             adp.Fill(ds);
             Dropdownlist1.DataSource = ds;
             Dropdownlist1.DataTextField = "CountryName";
             Dropdownlist1.DataValueField = IndexOf("CountryID");
             Dropdownlist1.DataBind();
