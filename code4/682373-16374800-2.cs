    public static int AddSlider(string Imgname,string Imgalt)
    {
    int rows=-1;
    SqlConnection conn = new SqlConnection("connection string");
    conn.Open();
    string Query="insert into [slider](ImageName,ImageAlt) values(@Imgname,@Imagealt)";
    DbCommand cmd = DataGeneric.CreateCommand();
    cmd.Connection = conn;
    cmd.CommandText = Query;
    cmd.CreateAndSetParameter("@Imgname",DbType.String,50,Imgname);
    cmd.CreateAndSetParameter("@Imgalt", DbType.String, 50, Imgalt);
    rows = DataGeneric.ExecuteNonQuery(cmd);
    conn.Close();
    return rows;
    }
