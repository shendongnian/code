    var code = new SqlParameter("@Code", 1);
    var returnCode = new SqlParameter("@ReturnCode", SqlDbType.Int);
    returnCode.Direction = ParameterDirection.Output;
    var outParam = new SqlParameter("@StatusLog", SqlDbType.Int);
    outParam.Direction = ParameterDirection.Output;
    var sql = "exec @ReturnCode = spItemData @Code, @StatusLog OUT";
    var data = _context.Database.SqlQuery<Item>(sql, returnCode, code, outParam);
    // Read the results so that the output variables are accessible
    var item = data.FirstOrDefault();
    var returnCodeValue = (int)returnCode.Value;
    var outParamValue = (int)outParam.Value;
