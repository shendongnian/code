      class SimpleCase { 
        // Usual event realization (default add and remove accessors)
        public event EventHandler MyEvent; 
      }
    
      ...
      SimpleCase cs = new SimpleCase();
      cs.MyEvent += ...
      ...
    
      // Since MyEvent has default accessors, lets check the default storage: 
      FieldInfo fi = cs.GetType().GetField("MyEvent", BindingFlags.NonPublic | BindingFlags.Instance);
      Boolean myEventAssigned = !Object.ReferenceEquals(fi.GetValue(cs), null);
