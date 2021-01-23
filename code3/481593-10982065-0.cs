    public List<Record> GetAllRecordsByUserName(string credentials)
    {
        List<Record> recordList;
        using (CustomEntities context = new CustomEntities())
        {
    
            IQueryable<Record> recordQuery = from records in context.Records
                                                  where records.UserName == credentials
                                                  select records; 
            recordList = recordQuery.ToList<Record>();
        }
        return recordList;
    }
    public void ValidateAndBind(string username)
    {
        List<Record> recordList = GetAllRecordsByUserName(username);
        
        // Do validation here
        ddlTest.DataSource = recordList;
        ddlTest.DataBind();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        ValidateAndBind("test.username");
    }
