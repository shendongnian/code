    [HttpPost]
    public ResponseModel Handler(string name, List<AEntity> requestEntities)
    {
        //Populate RequestModel here..
        return CreateTableResponse(name, tableRequest);
    }
