    private void section_SelectedIndexChanged(object sender, EventArgs e)
    {
        string selected = (string)section.SelectedItem;
        using(SqlConnection conn1 = new SqlConnection(connString))
        {
            conn1.Open();
            string itemc = "select  distinct Itemcode from Items where Section1 like 'G%'";
            if(selected != "Giftarticles") itemc += " AND Section1 NOT LIKE 'H%'"
            SqlCommand cmditem = new SqlCommand(itemc, conn1);
            SqlDataReader dr2 = cmditem.ExecuteReader();
            while (dr2.Read())
                itemcode.Items.Add(dr2["Itemcode"].ToString());
            dr2.Close();
            conn1.Close();
        }
    }
