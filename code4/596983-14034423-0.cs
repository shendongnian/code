       Dictionary<string, object> values = new Dictionary<string,object>();
       values.Add("userid", 1022);
            values.Add("username", "JFord");
            values.Add("IsActive", 0);
            string table = "users";
            string strCommand = string.Format(
                "INSERT INTO {0} VALUES ({1})",
                table,
                "@"+String.Join(", @", values.Keys));
     //strCommand becomes: "INSERT INTO users VALUES (@userid, @username, @IsActive)"
            SqlCommand com = new SqlCommand(strCommand);
    
            foreach (string key in values.Keys)
            {
                com.Parameters.AddWithValue("@" + key, values[key]);
            }
