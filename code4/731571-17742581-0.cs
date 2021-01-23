    string[] tags = new string[] { "ruby", "rails", "scruffy", "rubyonrails" };
    string cmdText = "SELECT * FROM Tags {0}";
    string[] paramNames = tags.Select(
                (s, i) => "@tag" + i.ToString()
            ).ToArray();
    string cmdWhere = paramNames.Length > 0 ? String.Format("WHERE Name IN ({0})", string.Join(",", paramNames)) : "";
    using (SqlCommand cmd = new SqlCommand(string.Format(cmdText, cmdWhere)))
    {
        for (int i = 0; i < paramNames.Length; i++)
        {
            cmd.Parameters.AddWithValue(paramNames[i], tags[i]);
        }
    }
