    class MyClass : IDisposable
    {
       Socket m_listenerSocket = new Socket();
    
       public void Dispose()
       {
           m_listenerSocket.Dispose();
           innerClass.Notify -= Notify; 
       }
    }
