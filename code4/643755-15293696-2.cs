    class MyOtherClass : Clazz<MyOtherClass>
    {
        public override void CopyFrom(Clazz<MyOtherClass> source)
        {
            // implementation
        }
        // this list processing is inherited
        public override void ProcessList<TDescendant>(List<TDescendant> list)
        {
            // implementation
        }
        // this list processing is specific to this descendant only
        public void ProcessMyClassList<TDescendant>(List<TDescendant> list)
            where TDescendant : Clazz<TMyClass>
        {
            // implementation
        }
    }
