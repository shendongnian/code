    public interface RandomInterface {
       Foo Value { get; set; }
    }
    public interface AlternativeInterface {
       Bar Value { get; set; }
    }
    public class Orange : RandomInterface {
    }
    public class Banana : AlternativeInterface {
    }
