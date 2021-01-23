    public IEnumerable<Log_Deposits_Interest_Master> GetDepositsPendingRecord(string glCode, int fromDateID)
    {
      using(var db = new DataClasses1DataContext())
        foreach(Log_Deposits_Interest_Master item in db.sys_Log_Deposits_Interest_Masters.Where(deposits => deposits.cGLCode.Equals(glCode) && deposits.nFromDateID.Equals(fromDateID))
          yield return item;
    }
