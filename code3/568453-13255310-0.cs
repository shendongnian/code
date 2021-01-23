    bool timedOut = false;
    DateTime timeout = DateTime.Now.AddSeconds(timeoutSeconds);
    while ( MyClass.MyUsbDevice == null ) {
       if( DateTime.Now > timeout ) {
          timedOut = true;
          break;
       }
       Thread.Sleep(0); // Avoid pegging the CPU, yield it to other processes
    }
    
    if( !timedOut ) {
       // run the script
    } else {
       // Handle timeout
    }
