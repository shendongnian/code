    using (StreamReader sr = new StreamReader(Server.MapPath("keys.txt")))
        {
            string keys = sr.ReadToEnd();
            string[] allkeys = Regex.Split(keys, "\r\n");
            foreach (string values in allkeys)
            {
                SqlCommand cmd = new SqlCommand("select count(newkey) from serialkey where newkey ='" + values.ToString() + "'", con);
                int keyvalue = Convert.ToInt32(cmd.ExecuteScalar());
                if (keyvalue == 0)
                {
                    com = new SqlCommand("insert into SerialKey (productid,productfeatures,newkey) values ('" + productid.ToString() + "','" + productfeature.ToString() + "','" + key + "')", con);
                    com.ExecuteNonQuery();
                }
            }
            sr.Close();
            File.WriteAllText(Server.MapPath("keys.txt"), string.Empty);
    }
