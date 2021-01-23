    public class Test<T>
    {
       public T yourVariable;  
    }
    Test<int> intClass = new Test();
    Test<string> stringClass = new Test();
    intClass.yourVariable // would be of type int
    stringClass.yourVariable // would be of type string
