    public void MyMethod()
    {
        object[] generatorOutput = Generator.Generate(args);
        aList = (MyList<A>)generatorOutput[0];
        bList = (MyList<B>)generatorOutput[1]; // First error here
        // ...
        var bList = new MyList<B>();  // <---  // Second error here
