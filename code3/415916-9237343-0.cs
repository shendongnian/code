    class Parent {
    }
    class Child : Parent {
    }
    interface I<in T> {
        T Get(); // Imagine this actually compiles.
    }
    class G<T> : I<T> where T : new() {
        public T Get() {
            return new T();
        }
    }
    // ...
    I<Child> g = new G<Parent>(); // OK since T is declared as contravariant, thus "reversing" the type hierarchy, as explained above.
    Child child = g.Get(); // Yuck!
