    class SomeClass
    {
        public string SomeString { get; set; }
        public int SomeInt { get; set; }
        public DateTime SomeDateTime { get; set; }
        public bool Equals(object other)
        {
            SomeClass other1 = other as SomeClass;
            if (other1 != null)
                return other1.SomeInt.Equals(SomeInt)
                    && other1.SomeDateTime.Equals(SomeDateTime)
                    && other1.SomeString.Equals(SomeString); //or whatever string equality check you prefer
            //possibly check for other types here, if necessary
            return false;
        }
    }
