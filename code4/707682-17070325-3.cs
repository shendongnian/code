    class SomeObject
    {
        private AnotherObject Thing;
        public AnotherObject TheThing
        {
            get { return Thing.Copy(); }
        }
        public void RenameThing(string name)
        {
            Thing.Name = name;
        }
        // etc.
    }
