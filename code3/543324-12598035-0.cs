    public SomeClass
    {
        public SomeValue SomeProperty { get; set; }
        ...
        private bool ValidateProperties()
        {
            if (this.SomeProperty == SomeValue.Bad)
            {
                return false;
            }
            return true;
        }
    }
