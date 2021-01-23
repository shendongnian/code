    var args = new DynamicParameters(
        new { Data.Name, Data.OrganicTitle, Data.UserName, Data.Password});
    // note: ^^ are actually specifying implicit names
    args.Add("Result", direction: ParameterDirection.Output);
    connection.Execute("spSetUser", args, commandType: CommandType.StoredProcedure);
    return args.Get<int>("Result");
