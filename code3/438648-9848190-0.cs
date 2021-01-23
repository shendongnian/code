    void ReceiveMessage( IMessage message ) {
      if( message as DummyMessage != null ) HandleMessage( message as DummyMessage );
      else if( message as SillyMessage != null ) HandleMessage( message as SillyMessage );
      // etc
    }
