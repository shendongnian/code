    [HttpGet]
    public IEnumerable<string> GetAll()
    {
        return GetStrings(new int[]{});
    }
    
    [HttpGet]
    public string GetOneById(int id)
    {
        return GetStrings(new int[]{id}).FirstOrDefault();
    }
    private IEnumerable<string> GetStrings(int[] ids)
    {
         return // fetch strings using int array
    }
