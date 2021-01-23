    public class MyClass
    {
        private string myString = "blah";
        public string MyNotNullString
        {
            get
            {
                return this.myString;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Cannot set MyNotNullString to null");
                }
                this.myString = value;
            }
        }
    }
