    var sql = "INSERT INTO My_RSS ( Title, Description, Date, Link, Rate, Name )
               VALUES ( @Title, @Desc, @PostDate, @Link, @Rate, @Name )";
    SqlCommand cmd = new SqlCommand(sql, Connect());
    cmd.Parameters.Add("@Title", SqlDbType.VarChar, 100).Value = RSS_title;
    cmd.Parameters.Add("@Desc", SqlDbType.VarChar, 8192).Value = RSS_description;
    cmd.Parameters.Add("@PostDate", SqlDbType.SmallDateTime).Value = DateTime.Now;
    cmd.Parameters.Add("@Rate", SqlDbType.Int).Value = rate;
