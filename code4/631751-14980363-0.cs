    public class MyClass
    {
        public string Fruits {get;set;}
        
        public string [] FruitList {
            get { return Fruits.Split(new [] {','}); }
            //warning, the setter is dangerous
            set { Fruits = string.Join(',', value); }
        }
    }
