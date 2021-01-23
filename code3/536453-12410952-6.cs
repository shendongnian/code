    using (var thing = new SomeClass())
    {
        using (var another = new Another())
        {
            using (var somethingElse = new Whatever())
            {
                //...
            }
        }
    }
