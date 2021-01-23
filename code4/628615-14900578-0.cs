    class Var3Comparer : IEqualityComparer<MyClass> {
        public int GetHashCode(MyClass obj) {
            return (obj.Var3 ?? string.Empty).GetHashCode();
        }
        public bool Equals(MyClass x, MyClass y) {
            return x.Var3 == y.Var3;
        }
    }
    // ...
    var distinct = list.Distinct(new Var3Comparer());
