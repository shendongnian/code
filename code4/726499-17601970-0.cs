    //you create sub-query which contains all your codes and evaluate it
    var query = RCode.ToList();
    var RJDEReasonCode = from a in JDETable.F0005
                         where
                             a.DRSY.Equals("00") &&
                             a.DRDL01 != null &&
                             (a.DRRT.Equals("W4") ||
                             a.DRRT.Equals("W5")) &&
                             //and use it checking if it contains a.DRKY.Trim() 
                             query.Conatins(a.DRKY.Trim())
                          select new
                          {
                                         CATEGORY_CODE = a.DRRT,
                                         REASON_CODE = a.DRKY,
                                         DESCRIPTION = a.DRDL01
                          };
