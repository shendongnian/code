        private Int32[] numbers;
        public object Numbers
        {
            get { return numbers; }
            set
            {
                if (value.GetType() == typeof(Int32))
                {
                    numbers = new Int32[] { (Int32)value };
                }
                else if (value.GetType() == typeof(Int32[]))
                {
                    numbers = (Int32[])value;
                }
            }
        }
