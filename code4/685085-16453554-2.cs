    public class Class1
    {
        private int number;
        public int Number
        {
            get { return number; }
        }
        private string name;
        public string Name
        {
            get { return name; }
        }
        private bool isTrue;
        public bool IsTrue
        {
            get { return isTrue; }
        }
        public Class1()
        {
            number = 1;
            name = "FirstString";
            isTrue = true;
        }
        public Class1(int value1, string value2, bool value3)
        {
            number = value1;
            name = value2;
            isTrue = value3;
        }
    }
    public class Class2
    {
        private Class1 firstClass;
        private Class1 secondClass;
        public Class2()
        {
            firstClass = new Class1();
            secondClass = new Class1(2, "SecondString", false);
        }
    }
