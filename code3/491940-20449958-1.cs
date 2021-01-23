    public class MyGenericClass<TSomeClass> {
        public static void MyGenericMethod<TSomeClass, TSomeInterface>
                                             (MyGenericClass<TSomeClass> that) 
            where TSomeClass : TSomeInterface 
        {
            // use "that" instead of this
        }
    }
