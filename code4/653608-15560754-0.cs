    class SqlParamBinding {
        string Name {get;set;}
        object Value {get;set;} 
    }
    var lstExpResult = new List<SqlParamBinding> {
        new SqlParamBinding { Name = "NormalCounter", Value = CountHrs.NormalCounter}
    ,   new SqlParamBinding { Name = "SATCounter", Value = CountHrs.SATCounter}
    ,   new SqlParamBinding { Name = "SUNCounter", Value = CountHrs.SUNCounter}
    };
    UpdateBooking(bookingSesid, lstExpResult);
