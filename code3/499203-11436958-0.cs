    public void Foo<T>(T parameter) where T: class {
        otherObject.Bar<T>(parameter);
    }
    void IFoo.Foo<T>(T parameter){
        Foo((dynamic)parameter);
    }
