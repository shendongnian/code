    public void ProcessRequest(HttpContext context)
    {
        int mailid = int.Parse(context.Request["mid"]);
        var detail = GetMailDetail(mailid);
        if (detail != null)
        {
            context.Response.ContentType = "application/json";
            string json = new JavaScriptSerializer().Serialize(detail);
            context.Response.Write(json);
        }
        else
        {
            context.Response.StatusCode = 404;
        }
    }
    protected object GetMailDetail(int mailid)
    {
        string sql = "select m.datesent, m.subject, m.message, u.firstname, u.lastname from mail m inner join users u on m.senderid = u.userid where m.mailid = @id";
        var args = new[]
        {
            new MySqlParameter 
            { 
                ParameterName = "@id", 
                MySqlDbType = MySqlDbType.Int32, 
                Value = mailid 
            }
        }.ToList();
        using (MySqlContext db = new MySqlContext())
        using (MySqlDataReader dr = db.getReader(sql, args))
        {
            if (dr.Read())
            {
                return new 
                {
                    From = string.Format("{0} {1}", dr["firstname"], dr["lastname"]),
                    Date = dr.GetDateTime("datesent").ToString("yyyy/MM/dd HH:mm:ss"),
                    Subject = dr["subject"],
                    Message = dr["message"]
                }
            }
            return null;
        }
    }
