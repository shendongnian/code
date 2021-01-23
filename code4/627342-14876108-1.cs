    class ClassA
    {
        private ClassA a;
        [DoNotSerialize]
        public ClassA A
        {
            get
            {
                if (a == null)
                    a = new ClassA();
                return a;
            }
        }
    }
