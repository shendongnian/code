    public void Setup()
    {
        MyAnim.Completed+=CompletedExecution;
    }
    private void CompletedExecution(object sender, EventArgs args)
    {
        bool runAnotherAnim;
        lock(_locker)
        {
            runAnotherAnim=_waitingAnimations>0;
            if(_waitingAnimations>0)
                 _waitingAnimations--;
            
        }
        if(runAnotherAnim)
            MyAnim.Begin();
        else
            _isProcessing=false;
    }
    public void AddAnimation()
    {
       lock(_locker)
       {
           if(_isProcessing)
           {
               _waitingAnimations++;
           }
           else
           {
               _isProcessing=true;
               MyAnim.Begin();
              
           }
       }
    
    }
