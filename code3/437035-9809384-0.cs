    class Images
    {
        public int Image_ID;
    }
    protected void RepeaterUpdates_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        RepeaterItem item = e.Item;
        TextBox Update_ID = (TextBox)item.FindControl("TextBoxUpdateID_Repeater");
    
        try
        {
            conn5.Open();
            using (SqlCommand cmd5 = new SqlCommand("SelectImages", conn5))
            {
                cmd5.CommandType = CommandType.StoredProcedure;
                cmd5.Parameters.Add(new SqlParameter("@update_id", Update_ID.Text));
                List<Images> Lst = new List<Images>();
    
                using (SqlDataReader rdr5 = cmd5.ExecuteReader())
                {
                    while (rdr5.Read())
                    {
                        Lst.Add(new Images { Image_ID = Convert.ToInt16(rdr5["Image_ID"]) });
                    }
                    if ((item.ItemType == ListItemType.Item) || (item.ItemType == ListItemType.AlternatingItem))
                    {
                        Repeater ImageRepeater = (Repeater)item.FindControl("RepeaterImages");
                        ImageRepeater.DataSource = Lst;
                        ImageRepeater.DataBind();
                    }
                }
            }
        }
    
        finally
        {
            conn5.Close();
        }
    }
