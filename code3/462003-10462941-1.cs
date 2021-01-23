    IQueryable<TestViewClass> GetView()
    {
        return MyContext.Tests.Select(t => new TestViewClass
        {
                           FirstName = t.fName, 
                           SurName = t.lName, 
                           LastName = t.lName, 
                           Age = t.Age 
        }; 
    }
