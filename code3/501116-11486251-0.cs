    [WebMethod]
    [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
    public List<Tag> GetTags()
    {
        List<Tag> TagList = new List<Tag>();
        DataTable dt = Helpers.Tags.GetTags();
        foreach (DataRow dr in dt.Rows)
        {
            Tag t = new Tag();
            t.TagName = dr["Tag"].ToString();
            t.TagDescription = dr["Description"].ToString();
            TagList.Add(t);
        }
        return TagList;
    }
