    class MyClass
    {
        public readonly string Name = "Default Name";
        private int intVal;
        public int Val
        {
            get
            {
                return intVal;
            }
            set
            {
                if (0 <= value && value <= 10)
                    intVal = value;
                else
                    throw (new ArgumentOutOfRangeException("Val", value,
                        "Val must be assigned a value between 0 and 10."));
            }
        }
        public override string ToString()
        {
            return "Name: " + Name + "\nVal: " + Val;
        }
        public MyClass(string newName)
        {
            Name = newName;
            intVal = 0;
        }
    }
