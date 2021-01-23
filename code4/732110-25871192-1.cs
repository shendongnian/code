    public void DataTableParameters()
    {
        try { connection.Execute("drop proc #DataTableParameters"); } catch { }
        try { connection.Execute("drop table #DataTableParameters"); } catch { }
        try { connection.Execute("drop type MyTVPType"); } catch { }
        connection.Execute("create type MyTVPType as table (id int)");
        connection.Execute("create proc #DataTableParameters @ids MyTVPType readonly as select count(1) from @ids");
        var table = new DataTable { Columns = { { "id", typeof(int) } }, Rows = { { 1 }, { 2 }, { 3 } } };
        int count = connection.Query<int>("#DataTableParameters", new { ids = table.AsTableValuedParameter() }, commandType: CommandType.StoredProcedure).First();
        count.IsEqualTo(3);
        count = connection.Query<int>("select count(1) from @ids", new { ids = table.AsTableValuedParameter("MyTVPType") }).First();
        count.IsEqualTo(3);
        try
        {
            connection.Query<int>("select count(1) from @ids", new { ids = table.AsTableValuedParameter() }).First();
            throw new InvalidOperationException();
        } catch (Exception ex)
        {
            ex.Message.Equals("The table type parameter 'ids' must have a valid type name.");
        }
    }
