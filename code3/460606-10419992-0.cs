    abstract class ClassC : ClassA
    {
        public override sealed void Method1(ClassB parameter)
        {
            this.Method1(parameter as ClassD);
        }
        public abstract void Method1(ClassD parameter);
    }
