    public List<Parts> GetParts()
    {
        List<Parts> lst = new List<Parts>(); 
        using (SqlConnection cnx = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["request"].ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM REQUESTS", cnx);
            cnx.Open();
            Parts parts = null; 
            SqlDataReader dataReader = cmd.ExecuteReader();
            { 
                while (dataReader.Read())
                {
                    parts = new Parts();
                    parts.computername = dataReader["titlename"].ToString();
                    lst.Add(parts);
                }
            }
        }
        return lst;
    } 
    public void SomeMethod(List<Parts> parts)
    {
        List<string> title = new List<string>();
        foreach(var item in parts)
        {
            title.Add(item.titlename);
        }
        this.ddlPartsTitle.Datasource = title;
        this.ddlPartsTitle.DataBind();
    }
    public YourClassName()
    {
        this.SomeMethod(this.GetParts());
    }
