    public class SomeClass<T>
    
    {
    internal List<T> InternalList;
    public SomeClass() { InternalList = new List<T>(); }
    
    
    public void RemoveAll(T theValue)
    {
    // this will work
    InternalList.RemoveAll(x =< x.Equals(theValue));
    
    // the usual form of Lambda Predicate 
    //for RemoveAll will not compile
    // error: Cannot apply operator '==' to operands of Type 'T' and 'T'
    // InternalList.RemoveAll(x =&amp;gt; x == theValue);
    }
    }
