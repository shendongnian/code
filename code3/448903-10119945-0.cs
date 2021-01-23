      try
      {
        teacher = new Teacher( "", st ); //this line raises an exception 
                                         // so teacher REMAINS NULL. 
                                         // it's NOT ASSIGNED to NULL, 
                                         // but just NOT initialized. That is.
      }
      catch ( Exception e )
      {
        Console.WriteLine( e.Message );
      }
