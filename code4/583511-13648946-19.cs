    [HttpGet]
    public NJsonResult GetUsers(string ids)
    {
        var result = ExecuteCommand(new GetUsers
                                        {
                                            IDs = ids
                                        });
        //...
    }
