      [NonPersistent]
      public string Name {
       get {
        try {
     	   return (FirstName + " " + LastName).Trim();
    	}
    	catch { }
    	return String.Empty;
       }
      }
