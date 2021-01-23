    public List<SelectListItem> getNames()
    {
        var list = new List<SelectedListItem>();
        try
        {
            using (SqlCommand com = new SqlCommand("SELECT * FROM Names", con))
            {
                con();
                SqlDataReader dr = com.ExecuteReader();
                while (dr.Read())
                {
                    var item = new SelectedListItem();
                    item.Value = dr[0];
                    list.Add(item);
                }
            }
        }
        catch(Exception ex)
        {
            // ...
        }
        return list;
    }
