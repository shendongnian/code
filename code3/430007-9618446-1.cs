      public void Run_Method1_Then_Method2_500_Milliseconds_Later()
      {
          DispatcherTimer timer = new DispatcherTimer();
          timer.Interval = TimeSpan.FromMilliseconds(500);
          timer.Tick += (s, e) =>
          {
              // do some quick work here in Method2
              Method2(timer);
          };
          Method1();      // Call Method1 and wait for completion
          timer.Start();  // Start Method2 500 milliseconds later
      }
      public void Method1()
      {
          // Do some work here
      }
      public void Method2(DispatcherTimer timer)
      {
          // Stop additional timer events
          timer.Stop();
          // Now do some work here
      }
