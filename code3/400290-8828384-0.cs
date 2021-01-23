    // Use as follows:
    // var f = new Foo() { x = 5, y = 5 };
    // var ten = f.MyUtility();
    public static class MyUtility {
        public static Int32 Add(this Foo foo) { return Foo.x + Foo.y; }
    }
