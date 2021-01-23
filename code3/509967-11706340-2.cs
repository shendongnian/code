    [WebMethod]
    public static List<string> GetAutoCompleteData(string strSearchKey)
    {
        AutoSearch_BLL objAutoSearch_BLL = new AutoSearch_BLL();
        List<string> result = new List<string>();
        result = objAutoSearch_BLL.AutoSearchEmployeesData(strSearchKey);
        return result;
    }
