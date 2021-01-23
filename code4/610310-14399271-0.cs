    public class MyClass
    {
        public string MyString;
        public MyClass(string stringToUse)
        {
           this.MyString = stringToUse;
        }
    
        public MyClass MakeMyClass(string str)
        {
           return new MyClass(str);
        }
    }
