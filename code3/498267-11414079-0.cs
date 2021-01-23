    class Foo
    {
        private bool property;
        public bool Property
        {
            get
            {
                return this.property;
            }
            set
            {
                notifySomethingOfTheChange();
                this.property = value
            }
        }
    }
