        public override int MyProperty
        {
            get
            {
                return 5;
            }
            set
            {
                throw new Exception();
            }
        }
