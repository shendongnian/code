    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["ImageID"] != null)
       {
            string strQuery = "select Name, ContentType, Data from tblFiles where id=@id";
            SqlCommand cmd = new SqlCommand(strQuery);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value
            = Convert.ToInt32 (Request.QueryString["ImageID"]);
            DataTable dt = GetData(cmd);
            if (dt != null)
            {
                Byte[] bytes = (Byte[])dt.Rows[0]["Data"];
                Response.Buffer = true;
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = dt.Rows[0]["ContentType"].ToString();
                Response.AddHeader("content-disposition", "attachment;filename="
                + dt.Rows[0]["Name"].ToString());
                Response.BinaryWrite(bytes);
                Response.Flush();
                Response.End();
            }
        }
    }
