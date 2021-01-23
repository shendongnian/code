    interface IFooVisitor {
        void Visit<T>(Foo<T> foo);
    }
    class DoSomethingFooVisitor : IFooVisitor {
        public void Visit<T>(Foo<T> foo) {
            // ...
        }
    }
    abstract class Foo {
        public abstract void Accept(IFooVisitor foo);
    }
    class Foo<T> : Foo {
        public override void Accept(IFooVisitor foo) {
            foo.Visit(this);
        }
        // ...
    }
    static class Functions {
        public static void DoSomething(List<Foo> list) {
            IFooVisitor visitor = new DoSomethingFooVisitor();
            foreach (Foo item in list)
                item.Accept(visitor);
        }
    }
