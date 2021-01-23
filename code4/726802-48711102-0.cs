    public void Issue261_Decimals()
    {
        var parameters = new DynamicParameters();
        parameters.Add("c", dbType: DbType.Decimal, direction: ParameterDirection.Output, precision: 10, scale: 5);
        connection.Execute("create proc #Issue261 @c decimal(10,5) OUTPUT as begin set @c=11.884 end");
        connection.Execute("#Issue261", parameters, commandType: CommandType.StoredProcedure);
        var c = parameters.Get<Decimal>("c");
        c.IsEqualTo(11.884M);
    }
