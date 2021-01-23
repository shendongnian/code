    [ScriptableType]
    public class TestClass
    {
        public object arrayObj;
        public object dicObj;
        public TestClass sibling;
    
        public TestClass(){}
        public void testMethod(TestClass testClassObj)
        {
                                   //Assuming argument came from Javascript
                                   //& arrayObj and dicObj were assigned an 
                                   //Array and dictionary-obj respectively
             testClassObj.arrayObj; //Formal type: Object. Actual type: object[]
             testClassObj.dicObj;   //Formal type: Object. Actual type: 
                                    //                     Dictionary<string, object>
        }
    }
