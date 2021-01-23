        public DateTime? GetValue()
        {
            DateTime? value = null;
            // Regular way
            value = GetValueImpl1();
            if (value != null)
                return value;
            // Fall back 1
            value = GetValueImpl2();
            if (value != null)
                return value;
            // Fall back 2
            value = GetValueImpl3();
            if (value != null)
                return value;
            return null;
        }
        private DateTime? GetValueImpl1()
        {
            return new DateTime();
        }
        private DateTime? GetValueImpl2()
        {
            return new DateTime();
        }
        private DateTime? GetValueImpl3()
        {
            return new DateTime();
        }
