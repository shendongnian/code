    var someInt = GetSomeInt();
    Assert.AreEqual(5, someInt.Value);
    var someString = GetSomeString();
    Assert.AreEqual("ok", someString.Value);
    // ...
    public interface IDifferentTypes<T>
    {
        T Value { get; set; }
    }
    public class IntegerType : IDifferentTypes<int>
    {
        public int Value { get; set; }
    }
    public class StringType : IDifferentTypes<string>
    {
        public string Value { get; set; }
    }
    public class DateTimeType : IDifferentTypes<DateTime>
    {
        public DateTime Value { get; set; }
    }
