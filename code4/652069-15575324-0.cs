    if (dateTo.Minute > 30)
       minToInt = 30;
    else
       minToInt = 00;
     
    dateFrom = DateTime.Now;
    dateTo = DateTime.Now;     
    DateTime dateFrom = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, dateFrom.Hour, 00, 00);
    DateTime dateTo = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, dateTo.Hour, minToInt, 00);
    ////////FROM DATE/////////
    OracleParameter fromDateParameter = new OracleParameter();
    fromDateParameter.OracleDbType = OracleDbType.Date;
    fromDateParameter.Value = dateFrom;
    ////////TO DATE/////////
    OracleParameter toDateParameter = new OracleParameter();
    toDateParameter.OracleDbType = OracleDbType.Date;
    toDateParameter.Value = dateTo;
 
    this.oracleDataAdapter4.SelectCommand = new OracleCommand("
       SELECT DISTINCT (LOG.RID) FROM LOG WHERE LOG.TIMESTAMP 
       BETWEEN :fromDateParameter 
       AND :fromDateParameter)", oracleConnection4);
    
    oracleDataAdapter4.SelectCommand.Parameters.Add(fromDateParameter);           
    oracleDataAdapter4.SelectCommand.Parameters.Add(toDateParameter);  
    this.oracleDataAdapter4.Fill(event11);
