    public class ExampleItem
    {
        public string MyString;
        public ExampleItem(string stringToUse)
        {
           this.MyString = stringToUse;
        }
    
        public ExampleItem MakeExampleItem(string str)
        {
           return new ExampleItem(str);
        }
    }
