    public class DependencyProxy : IDependencyProxy {
        public string Foo() {
            return new Dependency.Foo();
        }
    }
