    public enum Foo
    {
        Boo,
        Koo
    }
    
    public Foo foo { get; set; }
    
    [Fact]
    public void FactMethodName()
    {
        foo = Foo.Koo;
        var propertyInfo = this.GetType().GetProperty("foo");
        if (propertyInfo.PropertyType.IsEnum)
        {
            var value = propertyInfo.GetValue(this, null);
            Console.Out.WriteLine("value = {0}", value); //prints Koo
            int asInt = (int)value;
            Console.Out.WriteLine("asInt = {0}", asInt); //prints 1
        }
    }
