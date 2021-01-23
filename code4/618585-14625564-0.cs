    var stub = new StubIObject
    {
        Foo = (value) => 
           {
               if (value == 100)  
                  // This covers the case (It.Is<int>(t => t == 100))
                  return value * 1.10;
               return value;    // This covers the default case (It.IsAny<T>)
            }
    };
