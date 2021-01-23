    public static Enumerable<T> ExtensionMethod(this ExtendedObject p1, dynamic p2) {
        //Do Stuff
    }
    
    dynamic y = something;
    var x = new ExtendedObject();
    
    //this works
    var returnedEnumerable = x.ExtensionMethod(y); 
    
    //this doesn't work
    var returnedValue = x.ExtensionMethod(y).SomeEnumerableExtensionMethodLikeFirst() 
