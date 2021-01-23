    [HttpGet]
    public NJsonResult GetProjects(string ids)
    {
        var result = ExecuteCommand(new GetProjects
                                        {
                                            IDs = ids
                                        });
        //...
    }
