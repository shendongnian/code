    class Result
    {
        public int PersonID;
        public string Name;
        public Result(int id, string name)
        {
            PersonID = id;
            Name = name;
        }
    }
    IEnumerable<Result> results = context.People.Select(p => new Result(p.PersonID, p.Name));
