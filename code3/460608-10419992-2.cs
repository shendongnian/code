    abstract class ClassC : ClassA
    {
        public override sealed void Method1(ClassB parameter)
        {
            if (!(parameter is ClassD))
                throw new ArgumentException(
                    "Parameter must be of type ClassD.", "parameter");
            this.Method1((ClassD)parameter);
        }
        public abstract void Method1(ClassD parameter);
    }
