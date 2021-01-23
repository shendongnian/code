    var root = new Level0();
    root.Data = new Foo();
    root.List = new List<Level1>
    {
        new Level1()
        {
            Data = new Bar(),
            List = new List<Level2>
            {
                new Level2()
                {
                    Data = new Fubar()
                }
            }
        }
    };
