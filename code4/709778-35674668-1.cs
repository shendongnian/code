    void SomeMethod() 
    {
      // Create a collection
      var arr = new ArrayList(5);
      // Create a custom object
      var mo = new MyObject();
      // Create a WeakReference object from the custom object
      var wk = new WeakReference(mo);
      // Add the WeakReference object to the collection
      arr.Add(wk);
      // Retrieve the weak reference
      WeakReference weakReference = (WeakReference)arr[0];
      MyObject mob = null;
      if( weakReference.IsAlive ){
        mob = (MyOBject)weakReference.Target;
      }
      if(mob==null){
        // Resurrect the object as it has been garbage collected
      }
      //continue because we have the object
    }
    
