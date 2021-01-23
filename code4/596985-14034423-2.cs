    public static int Insert(string cs, string table, Dictionary<string,object> values)
    {
            string strCommand = string.Format("INSERT INTO {0} VALUES ({1})",
                table, "@"+String.Join(", @", values.Keys));
     //strCommand becomes: "INSERT INTO users VALUES (@userid, @username, @IsActive)"
            SqlCommand com = new SqlCommand(strCommand, conn);
    
            foreach (string key in values.Keys)
            {
                com.Parameters.AddWithValue("@" + key, values[key]);
            }
    }
