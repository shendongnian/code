      public void Init()       
      {       
        if (timer_ != null)
          throw new InvalidOperationException("Already initialized!");
        timer_ = new Timer();       
        timer_.Interval = 10000;       
        timer_.Tick += OnTimerTick;       
        timer_.Start();       
      }       
      private void OnTimerTick(object sender, EventArgs e) 
      { 
        if (timer_ != null)
        {
          timer_.Stop();
          timer_.Dispose();
          timer_ = null;
          // Your code
        }
      } 
