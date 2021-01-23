    class ClassA<TB, TC>
        where TB : ClassB<TB, TC>
        where TC : ClassC<TB, TC>
    {
        public TB MyPropB { get; set; }
        public TC MyPropC { get; set; }
    }
    class ClassB<TB, TC>
        where TB : ClassB<TB, TC>
        where TC : ClassC<TB, TC>
    {
        public TC MyPropC { get; set; }
    }
    class ClassC<TB, TC>
        where TB : ClassB<TB, TC>
        where TC : ClassC<TB, TC>
    {
        public TB MyPropB { get; set; }
    }
