    public class MyGenericClass<TSomeClass, TSomeInterface> {
        where TSomeClass : TSomeInterface 
        public void MyGenericMethod() // not so generic anymore :( 
        {
            //...
        }
    }
