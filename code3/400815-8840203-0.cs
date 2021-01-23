      var client = new Service1Client();
      client.GetDataCompleted += Client_GetDataCompleted; // specify the callback method
      client.GetDataAsync( 0 );
      // ...
    static void Client_GetDataCompleted( object sender, GetDataCompletedEventArgs e )
    {
      var response = e.Result;
      // ...
    }
