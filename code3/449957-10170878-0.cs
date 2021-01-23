    var qry = new Select().From(FOO.Tables.Account)
        .InnerJoin(FOO.Tables.Managers) // If the DB has no relation specify columns.
        .And(FOO.Account.Columns.MemberNumber).IsEqualTo(MemberNumber)
        .And(FOO.Account.Columns.ManagerID).IsEqualTo(FOO.Managers.Columns.ManagerID);
        .And(FOO.Account.Columns.Active).IsEqualTo(true)
    ;
    var rdr = qry.ExecuteReader();
