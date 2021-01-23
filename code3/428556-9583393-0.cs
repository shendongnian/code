    public void Method3()
    {
        Action<BitmapSource> useBs1 = (source) =>  use_of_bs1(source);
        if(Thread.CurrentThread == this.Dispatcher.Thread)
          {
    
        useBs1(bs1);
    }
    else
    {
       this.Dispatcher.Invoke(DispatcherPriority.Normal,userBs1, bs1);
    }
    
       
    }
