public class MyFooIndexableObject
{
    /* Note that "ValueType" and "IndexType" are 
     * just place holders for whatever type you
     * decide to make as your return type and 
     * index type respectively  
     *
     * Using a regular dictionary and an
     * extra variable to implement a default 
     * dictionary so it is not like the example 
     * is doing nothing.
     */
    private Dictionary<IndexType,ValueType> _internalCollection;
    private readonly ValueType _defaultValue = new ValueType();
    public void FooSet(IndexType index, ValueType value)
    {
        if( index == null)
            //want to disallow index being null
            throw new NullArgumentException("index");
    
        if(_internalCollection==null)
            _internalCollection = new Dictionary<IndexType,ValueType>();
    
        if ( value == null || value == _defaultValue )
           // want to remove it 
        {
            _internalCollection.Remove(index);
        }
        else
            _internalCollection[index]=value;
    }
    /* The Examples FooSet and FooGet 
     * would be similar method constructs to 
     * the ones made behind the scenes when 
     * you define the getter and setter for 
     * your indexed object 
     */
    public ValueType FooGet(IndexType index)
    {
        if( _internalCollection == null 
            || !_internalCollection.Contains(index) )
                return new _defaultValue;
    
        return _internalCollection[index];
    }
    public bool TryGetValueAtFirstNonDefault(out IndexType outIndex,  
                                              out ValueType outValue)
    {
        outParam = outIndex = null;
        if(_internalCollection!=null)
        {
            // no need to check we maintain this in the setter and getter
            var temp= _internalCollection.FirstOrDefault();
            if(temp!=null)
            {
                outParam = temp.Value;
                outIndex = temp.Key;
            }
        }
        return outParam != null;
    }
    private static void Swap( ref ValueType someRefParam, 
                       ref ValueType otherRefParam)
    {
        var temp = someRefParam;
        someRefParam = otherRefParam;
        otherRefParam = temp;
    }
    
    //use this instead
    public void SwapValueAtIndexes(IndexType index1, IndexType index2)
    {
        var temp = this.FooGet(index1);
        this.FooSet(index1, this.FooGet(index2) );
        this.FooSet(index2, temp);
    }
    public static void Main(string[] args)
    {
        var indexable = new MyFooIndexableObject();
        var index1 = new IndexType(0);
        var index2 = new IndexType(1);
        ValueType someValue;
        
        //do someValue = indexable[index1]
        someValue = indexable.FooGet(index1);
        
        //do indexable[index1] = new ValueType()
        indexable.FooSet(index1,new ValueType());
        
        //this does not make sense will not work
        //do Swap( out indexable[index1], out indexable[index2] )
        //just look how you would try to do this
        Swap( ref indexable.FooGet(index1), ref indexable.FooGet(index2));
        //Swap is looking for reference to a location in memory
        //but the method is returning the value of an object reference
        //which you can store in a variable with a location in memory
        //but has yet been assigned to one
        //Please note the whole idea of "location in memory" is abstract
        //it does not technically mean an actual location in physical 
        //memory but probably an abstraction handled by .NET,
        //don't try to hard to make sure you have the technical part 
        //100% correct, you are significantly detached from the metal
        //when coding at this level...the basic idea is the same
        //as physical memory locations on a machine
        
        //However, you can accomplish the same things that you would
        //want to accomplish with "out" and "ref" by creating methods
        //that take the indexed object and an index, such as the
        //SwapValueAtIndex method
        
        indexable.SwapValueAtIndex(index1,index2);
        
        //While precisely what SwapValueAtIndex does may
        //not translate to what Swap does logically
        //it is the same thing, which is good enough for us
        
    }
}
   
