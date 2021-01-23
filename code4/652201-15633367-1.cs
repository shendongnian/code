    [WebMethod]
    public static string DeleteRecord(string Id, string TableName, string PrimaryKey)
    {
        String result = "";
        try
        {
            Id = "'" + Id + "'";
            clsSearch objSearch = new clsSearch();
            result = objSearch.DeleteRecord(TableName, PrimaryKey, Id);
            result = "1";
        }
        catch (Exception ex)
        {
            result = ex.Message;
        }
        return result;
    }
