    var sample = new List<MyClass>
    {
        new MyClass
        {
            SomeProperty = "Help",
            Method = new Action(() =>
              {
                  ExecuteMethod1("Hello", "World");
              })
        },
        new MyClass
        {
            SomeProperty = "Me",
            Method = new Action(() =>
              {
                  ExecuteMethod2(1, 2, 3, 4);
              })
        },
    };
