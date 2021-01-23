    public enum MyEnum
    {
      Foo = 100,
      Bar = 200,
      Fizz = 0
    }
    static void Main(string[] args)
    {
      var i1 = MyEnum.Foo.GetHashCode();  // i1 = 100
      var i2 = MyEnum.Bar.GetHashCode();  // i2 = 200
      var i3 = MyEnum.Fizz.GetHashCode(); // i3 = 0
    }
