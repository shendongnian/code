    var sync = new object();
    var myNewList = new List<SomeObject>();
    Parallel.ForEach(myListOfSomethings, a =>
        {
            // Some other code...
            var someObj = new SomeObject();
            // More other code...
            lock(sync)
            {
                myNewList.Add(someObj);
            }
            // Even more code...
        });
