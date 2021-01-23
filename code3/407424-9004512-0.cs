    bool isMreSync = true;
    var myObjectWithEvents = new ObjectWithEvents();
    using (var mre = new ManualResetEvent(false)) 
    {
        var onEvent = new EventHandler<EventArgs>((sender, e) => 
                     { 
                         if (isMreSync)
                         {
                             mre.Set(); 
                         }
                     });
      // try ... finally block	
     }
    
    isMreSync = false;
