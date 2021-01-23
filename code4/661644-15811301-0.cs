    public List<MyObject> Search(string input)
    {
        return Data.GetAllObjects()
            .Where(obj => obj.SubObjects
                .Any(subobj => subobj.SubOjectId.Equals(input)));
    }
