    public FirsTable GetNetSumByUserID(int UserId)
    {
      double income = dbcontext.Income.Where(g => g.UserID == UserId).Select(f => f.inSum);
      double expenses = dbcontext.Outcome.Where(g => g.UserID == UserId).Select(f => f.outSum);
      double sum = (income - expense);
      FirstTable _FirsTable = new FirstTable{ UserID = UserId, Sum = sum};
      return _FirstTable;
    }
