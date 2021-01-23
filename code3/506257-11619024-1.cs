    //this class implements the non-generic interface, so buffer is an IList.
    class MyMessage1: IMessage
    {
       public IList buffer {get;set;}
    
       public MyMessage1()
       {
          buffer = new List<string>();
    
          //even though you "know" what you just assigned, 
          //you cannot refer to buffer as a List<string>, even here.
          buffer.Sort(); //error
       }
    }
    ...
    
    //The exact type of buffer cannot be known statically, 
    //so only non-generic IList methods are allowed
    var myMessage = new MyMessage1();
    myMessage.buffer.Add("my message"); //valid; string literals are Objects
    var firstLen = myMessage.buffer[0].Length; //error: indexer returns Objects.
    myMessage.Sort(); //error: IList does not have a Sort() method.
    firstLen = GetFirstLength(myMessage); //error: not an IMessage<List<string>>
    //but, an IList is an IList no matter what, so this works.
    myMessage.buffer = new List<int>(); 
    ...
    //this class keeps the generic open so T can be any IList, determined at instantiation.
    class MyMessage2<T>:IMessage<T> where T:IList
    {
        public T buffer {get;set;}
    
        //buffer's exact type is still not known here,
        //so inside this class you are still restricted to IList members only
        public int BufferCount{get{return buffer.Count;}}
        public void SortBuffer()
        {
           buffer.Sort(); //error; no such method
        }    
    }
    
    ...
    
    //but, once you define an instance, you know exactly what buffer is
    var myMessage = new MyMessage2<List<string>>();
    myMessage.buffer.Add("my message");
    var firstLen = myMessage.buffer[0].Length; //now we know the indexer produces strings.
    myMessage.buffer.Sort(); //buffer is known to be a List<T> which has Sort()
    firstLen = GetFirstLength(myMessage);
    ...
    //and when you pass it as a parameter, you can close the generic of the interface
    public string GetFirstLength(IMessage<List<string>> message) 
    {
       //...so you still know what you're dealing with
       return message.buffer[0].Length;
    }
    ...
    //however, buffer is now "strongly typed" and the implementation can't change
    myMessage.buffer = new List<int>(); //error; buffer is of type List<string>
    ...
    //this class closes the generic within the declaration.
    class MyMessage3:IMessage<IList<string>>
    {
       //now we're closing the generic in the implementation itself,
       //so internally we know exactly what we're dealing with
       public List<string> buffer {get;set;}
       //...so this call is valid
       public void SortBuffer() { buffer.Sort(); }
    }
    //...and consuming code doesn't have to (get to?) specify the implementation of T
    var myMessage = new MyMessage3();
    //... but still knows exactly what that implementation is
    myMessage.buffer.Add("my message");
    var firstLen = myMessage.buffer[0].Length;
    myMessage.buffer.Sort();
    //and btw, MyMessage3 is still an IMessage<List<string>>
    firstLen = GetFirstLength(myMessage);
    //... and buffer's still a strongly-typed List<string>
    myMessage.buffer = new List<int>(); //error
