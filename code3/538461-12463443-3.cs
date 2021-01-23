    A
    {
        var obj = new // Create an anonymous object.
        {
            // Define a method that needs an "object" parameter and returns nothing.
            Report = Return.Arguments<object>(m =>
            {
                // Do your thing.
            })
        }
 
        B(obj.ActLike<IProgress<Object>>);
    }
