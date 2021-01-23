    static void OnThePropChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
    {
         YourClass instance = (YourClass)obj;
         instance.ThePropChanged(args); // Call non-static
         // Alternatively, you can just call the callback directly:
         // instance.CallbackMethod(...)
    }
    // This is a non-static version of the dep. property changed event
    void ThePropChanged(DependencyPropertyChangedEventArgs args)
    {
          // Raise your callback here... 
    }
