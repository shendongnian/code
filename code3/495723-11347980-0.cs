    public List<Record> GetAllRecordsByUserName(string credentials)
    {
        List<Record> recordList;
        using (CustomEntities context = new CustomEntities())
        {
            IQueryable<Section> recordQuery = from records in context.Records
                                                  where records.UserName == credentials
                                                  select records; 
            recordList = recordQuery.ToList<Record>();
        }
        return recordList;
    }
    public void BindDropDown()
    {
        DropDownList1.DataSource = GetAllRecordsByUserName("test.user");
        DropDownList1.DataBind();
    }
