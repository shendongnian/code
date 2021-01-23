    public class MyRevisedClass {
        private readonly IDependencyProxy dependency;
        public MyRevisedClass() 
           : this( new DependencyProxy()) {}
        internal MyRevisedClass(IDependencyProxy dependency) {
            this.dependency = dependency;
        }
        public string MyFunc() {
            return dependency.Foo();
        }
    }
