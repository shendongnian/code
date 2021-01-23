    abstract class Base {
    }
    abstract class Intermediate : Base, IComparable<Base> {
    }
    class Class1 : Intermediate {
    }
    class Class2 : Intermediate {
    }
    class Class3 : Base {
    }
    public static List<Intermediate> BigList = new List<Intermediate>();
    BigList.Add(new Class1()); // ok
    BigList.Add(new Class2()); // ok
    BigList.Add(new Class3()); // error
