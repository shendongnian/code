    string s = "SELECT * "
            + "FROM San_Imovel_Caracteristica "
            + "WHERE Imovel_Id = " + imovel_id + " ";
        SqlConnection c = new SqlConnection(conn.Con);
        SqlCommand cmd = new SqlCommand(s, c);
        c.Open();
        SqlDataReader r = cmd.ExecuteReader();
        
        int outint;
        while (r.Read())
        {
            Object o = r["Varandas"];
            if (o != null && o != DbNull.Value)
            {
                if (int.TryParse(o.ToString(), out outint))
                {
                    XmlElement itemImovel1 = doc.CreateElement("itemImovel");
                    caracteristicasImovel.AppendChild(itemImovel1);
                    itemImovel1.InnerText = "varanda";
                }
            }
        }
