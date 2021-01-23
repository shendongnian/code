     try
      {
        m_COMObject.SomeMethod();
      }
    
      Exception(exception exception)
      {
        DisposeCOMObject();
        InitializeCOMOBject();
        COMObject.Somethod();
      }
    
    
     public void DisposeCOMObject()
    {
      m_COMObject = null;
      var process = Process.GetProcessesByNames("COM .exe").FirstDefault();
      
       if(process != null)
        {
             process.kill();
           }
    }
    
    
     public void InitializeCOMObject()
    {
      m_COMObject = null;
      m_COMObject = new COMObject();
    }
