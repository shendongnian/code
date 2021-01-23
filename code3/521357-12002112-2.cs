    public IQueryable<Log_Deposits_Interest_Master> GetDepositsPendingRecord(DataClasses1DataContext db, string glCode, int fromDateID)
    {
      return db.sys_Log_Deposits_Interest_Masters.Where(deposits => deposits.cGLCode.Equals(glCode) && deposits.nFromDateID.Equals(fromDateID));
    }
    
    public void UpdatePendingRecords(string glCode, int fromDateID)
    {
      using (var db = new DataClasses1DataContext())
      {
    
        var deposit = GetDepositsPendingRecord(db, glCode, fromDateID);
    
        foreach (var pending in deposit)
        {
          pending.cAuthorizedStatus = "Authorized";
          pending.dAuthorizedOn = DateTime.Now;
          pending.cAuthorizedBy = HttpContext.Current.User.Identity.Name;
    
        }
    
        //presumably you want to call db.SubmitChanges() here, no?
      }
    }
