      using (new WaitCursor()) {
        using (new RegisterServerLongOperation("My Long DB Operation")) {
          SomeLongRdbmsOperation();  
        }
    
        SomeLongOperation();
      }
