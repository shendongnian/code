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
            ...
            // Check other fields and properties here, return false on failure.
            ...
            return true;
        }
    }
