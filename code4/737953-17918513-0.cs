    private void download(DataTable dt)
    {
        // check if you have any rows at all 
        // no rows -> no data to convert!
        if(dt.Rows.Count <= 0)
           return;
        // check if your row #0 even contains data -> if not, you can't do anything!
        if(data.Rows[0].IsNull("profilepicture"))
           return;
        Byte[] bytes = (Byte[])dt.Rows[0]["profilepicture"];
        Response.Buffer = true;
        Response.Charset = "";
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "image/jpg";
        Response.BinaryWrite(bytes);
        Response.End();
    }
