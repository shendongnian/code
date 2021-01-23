    Thing theThing = myArray[index];
    if (theThing == null) // Doesn't look like it's created yet
    {
      Thing tempThing = new DummyThing(); // Cheap
      lock(tempThing) // Note that the lock surrounds the CompareExchange *and* initialization
      {
        theThing = System.Threading.Interlocked.CompareExchange
           (ref myArray[index], tempThing, null);
        if (theThing == null)
        {
          theThing = new RealThing(); // Expensive
          // Place an empty lock or memory barrier here if loose memory semantics require it
          myArray[index] = theThing ;
        }
      }
    }
    if (theThing is DummyThing)
    {
      lock(theThing) { } // Wait for thread that created DummyThing to release lock
      theThing = myArray[index];
      if (theThing is DummyThing)
          throw something; // Code that tried to initialize object failed to do so
      }
    }
