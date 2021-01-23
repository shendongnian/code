    public static CancellationTokenSource tokenSource; 
    [HttpPost]
        public ActionResult FinalImport(FormCollection collection)
          {
                tokensource=new CancellationTokenSource();
                Task.Factory.StartNew(() =>
                { 
                     if (ts.IsCancellationRequested)
                                {
                                    break;
                                }
                   //My Coding To Import
    
                } , tokenSource.Token);
    
                return null;
          }
    
       
    
        //Button Click on Cancel 
        public void CancelToken()
        {
            
            tokenSource.Cancel();
            tokensource.Dispose();
        }
