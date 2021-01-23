    public string ConvertDataTabletoString()
    {
    DataTable dt = new DataTable();
    DataTable dt1 = new DataTable();
    using (SqlConnection con = new SqlConnection("Data Source=SureshDasari;Initial Catalog=master;Integrated Security=true"))
    {
        using (SqlCommand cmd = new SqlCommand("select title=City,lat=latitude,lng=longitude,description from LocationDetails", con))
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
            Dictionary<string, object> row;
            foreach (DataRow dr in dt.Rows)
            {
                row = new Dictionary<string, object>();
                foreach (DataColumn col in dt.Columns)
                {
                    row.Add(col.ColumnName, dr[col]);
                }
                rows.Add(row);
            }
            SqlCommand cmd1 = new SqlCommand("_another_query_", con);
                    SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                    da1.Fill(dt1);
                    System.Web.Script.Serialization.JavaScriptSerializer serializer1 = new System.Web.Script.Serialization.JavaScriptSerializer();
                    Dictionary<string, object> row1;
                    foreach (DataRow dr in dt1.Rows) //use the old variable rows only
                    {
                        row1 = new Dictionary<string, object>();
                        foreach (DataColumn col in dt1.Columns)
                        {
                            row1.Add(col.ColumnName, dr[col]);
                        }
                        rows.Add(row1); // Finally You can add into old json array in this way
                    }
            return serializer.Serialize(rows);
        }
    }
    }
