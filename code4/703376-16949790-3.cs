    var x = new XListener("http://locahost:8080");
    
    x.StartListen();
    Thread.Sleep(500); // test purpose only
    
    x.StopListen();
    Thread.Sleep(500); // test purpose only
    
    x.StartListen();
    /* OUTPUT:
    => Listener started
    => Listener stopped
    => screw you guys, I'm going home!
    => Listener started */
