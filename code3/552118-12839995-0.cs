    class SomeTypeOfRow { // define something that looks like the results
        public int Id {get;set;}
        public string Name {get;set;}
        //..
    }
    ...
    var rows = connection.Query<SomeTypeOfRow>("StoredProcedureName",
        /* optionalParameters, */ commandType: CommandType.StoredProcedure).ToList();
