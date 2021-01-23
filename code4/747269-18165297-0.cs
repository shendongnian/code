    class MyClass : IArticle {
        public enum ConditionEnum { Red, Blue, Yellow };
    
        public ConditionEnum myenum;
    }
    
    MyClass c = new MyClass();
    c.myenum = MyClass.ConditionEnum.Red;
