    public class MySpringBeanWithDependency {
        private IWriter writer;
        public MySpringBeanWithDependency(IWriter writer) {
            this.writer = writer;
        }
    
        public void run() {
            String s = "This is my test";
            writer.writer(s);
        }
    }
    Kernel.Bind<IWriter>().To<SomeWriter>();
    Kernel.Get<MySpringBeanWithDependency>();
