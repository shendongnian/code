    [TestMethod]
    public void Test()
    {
        var test = new[] {
            new { Id = 1, Name = "John" },
            new { Id = 2, Name = "George" },
        };
        if (WhereIn(test.Select(a => a.Name)))
        {
				
        }
    }
    //Works with value types, strings, and classes
    public bool WhereIn<T>(IEnumerable<T> values)
    {
        var objectArray = new object[values.Count()];
        for (int index = 0; index < values.Count(); index++)
        {
            objectArray[index] = values.ElementAt(index);
        }
        return WhereIn(objectArray);
    }
    // This was just for test purposes
    public bool WhereIn(params object[] values)
    {
         return true;
    }
