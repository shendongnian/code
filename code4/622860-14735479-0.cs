    // define a new output parameter
    var returnCode = new SqlParameter();
    returnCode.ParameterName = "@ReturnCode";
    returnCode.SqlDbType = SqlDbType.Int;
    returnCode.Direction = ParameterDirection.Output;
    
    // assign the return code to the new output parameter and pass it to the sp
    var data = _context.Database.SqlQuery<Item>("exec @ReturnCode = spItemData @Code, @StatusLog OUT", returnCode, code, outParam);
