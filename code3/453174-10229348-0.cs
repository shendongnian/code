    [OperationContract]
    bool StockQuery(string partNo,String userName,String password);
    public bool StockQuery(string partNo,String userName,String password)
    {
        this.CheckSecurity(userName,password);
        if(partNo == "123456")
        {
            return true;
        }
        return false;
    }
