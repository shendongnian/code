Unhandled exception:
System.TypeInitializationException: The type initializer for 'SomeClass' threw an exception. ---> System.ArgumentException: An item with the same key has already been added.
   at System.ThrowHelper.ThrowArgumentException(ExceptionResource resource)
   at System.Collections.Generic.Dictionary`2.Insert(TKey key, TValue value, Boolean add)
   at System.Collections.Generic.Dictionary`2.Add(TKey key, TValue value)
   at SomeNamespace.SomeClass..cctor() in c:\ExceptionHandlingDemo.cs:line 43
   --- End of inner exception stack trace ---
   at SomeNamespace.SomeClass..ctor()
   at SomeNamespace.Callback() in c:\ExceptionHandlingDemo.cs:line 34
