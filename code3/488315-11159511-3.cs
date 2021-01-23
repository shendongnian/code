    public class PropertyExample
    {
        private int myIntField = 0;
        public int MyInt
        {
            // This is your getter.
            // it uses the accessibility of the property (public)
            get
            {
                return myIntField;
            }
            // this is your setter
            // Note: you can specify different accessibility
            // for your getter and setter.
            protected set
            {
                // You can put logic into your getters and setters
                // since they actually map to functions behind the scenes
                DoSomeValidation(value)
                {
                    // The input of the setter is always called "value"
                    // and is of the same type as your property definition
                    myIntField = value;
                }
            }
        }
    }
