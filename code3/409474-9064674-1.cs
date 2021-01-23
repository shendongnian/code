    public void MyMethod()
    {
        object[] generatorOutput = Generator.Generate(args);
        aList = (MyList<A>)generatorOutput[0];
        bList = (MyList<B>)generatorOutput[1];
        // ...
        var bList = new MyList<B>();  // <---
