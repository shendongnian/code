    methode1(){
       webBrowser1.Navigate("http://test.com");
    }
    methode2(){
       webBrowser1.Navigate("http://test2.com");
    }
    
    public void BatchRun()
    {
       methode1(); // run sync
       methode2(); // run sync after Method1
    }
    
    // ...
    
    Action toRun = BatchRun;
    toRun.BeginInvoke(null, null); // Run async
