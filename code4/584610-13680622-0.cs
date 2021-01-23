      this.SizeChanged += delegate
      {
          Dispatcher.BeginInvoke(DispatcherPriority.Background, (Action)delegate()
          {
              double screenWidth = SystemParameters.PrimaryScreenWidth;
              double screenHeight = SystemParameters.PrimaryScreenHeight;
              double windowWidth = this.Width;
              double windowHeight = this.Height;
              this.Left = (screenWidth / 2) - (windowWidth / 2);
              this.Top = (screenHeight / 2) - (windowHeight / 2);
          });
      };
      this.SizeChanged += delegate
      {
          ThreadPool.QueueUserWorkItem((o) =>
          {
              Thread.Sleep(100); //delay (ms)
              Dispatcher.Invoke(DispatcherPriority.Background, (Action)delegate()
              {
                  double screenWidth = SystemParameters.PrimaryScreenWidth;
                  double screenHeight = SystemParameters.PrimaryScreenHeight;
                  double windowWidth = this.Width;
                  double windowHeight = this.Height;
                  this.Left = (screenWidth / 2) - (windowWidth / 2);
                  this.Top = (screenHeight / 2) - (windowHeight / 2);
              });
          });
      };
