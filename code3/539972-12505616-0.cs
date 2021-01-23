    public class MyClass
    {
        public bool Flag { get; set; }
        public MyClass()
        {
            Flag = false;
        }
        public override string ToString()
        {
            if (Flag)
            {
                return "Ok";
            }
            else
            {
                return "Bad";
            }
        }
    }
