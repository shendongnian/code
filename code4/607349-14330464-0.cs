    //Get the data from your database 
    public IEnumerable<DataValue> GetDataValues()
    {
        try
        {
            using (var db = new MyEntities())
            {
                return (from data in db.DataValues
                       select data).ToList(); 
            }
        }
        catch(Exception e)
        {
            Console.WriteLine(e); 
        }
    }
    //Perform operations on the data
    public void DoSomething()
    {
        var data = GetDataValues(); 
        var result = data.Where(p => p.CategoryId == 2 && p.Uncle == "Bob"); 
        //etc...
    }
