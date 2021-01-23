    public List<SelectListItem> getNames()
    {
        var list = new List<SelectListItem>();
        try
        {
           using (SqlCommand com = new SqlCommand("SELECT * FROM Names", con))
           {
               con();
               SqlDataReader dr = com.ExecuteReader();
               while (dr.Read())
               {
                   list.Add(new SelectListItem { 
                              Value = dr.ReadString(0), // depends on your table
                              Text = dr.ReadString(1)  // depends on your table
                    }); 
               }
        catch(Exception e)
        {
            Trace.WriteLine(r.Message);
        }
        return list;
    }
