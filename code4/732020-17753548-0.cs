    private async void spin()
        {
    
            minSelTextBlock.Text = "";
    
                Index = 0;
                maxIndex = rnd.Next(40, 60);
                DispatcherTimer timer;
                timer = new DispatcherTimer(DispatcherPriority.Normal);
                timer.Interval = TimeSpan.FromMilliseconds(60);
                timer.Tick += new EventHandler(StartTicker);
                timer.Start();
                selPeople[x].IsCheck = false;
                displayCount++;
    
                Index = 0;
                maxIndex = rnd.Next(40, 60);
              
                await Ticker();
                 
                selPeople[x].IsCheck = false;
                displayCount++;
    
                displayImage2b.Source = new BitmapImage(new Uri(selPeople[0].ImgPath));          
        }
    
    
      Private Task<void> StartTicker()
      {
        Task.Run<void>(()=>Ticker());
      }
    
    private void Ticker()
        {
          while(your condition is true)
          {
            minSelTextBlock.Text = "";
    
            x = rnd.Next(0, selPeople.Count);
            while (x == temp)
            {
                x = rnd.Next(0, selPeople.Count);
            }
    
            if (displayCount == 0)
                displayImage1a.Source = new BitmapImage(new Uri(selPeople[x].ImgPath));
            if (displayCount == 1)
                displayImage2a.Source = new BitmapImage(new Uri(selPeople[x].ImgPath));
    
    
            if (++Index >= maxIndex)
            {
                break;
            }
            Index++;
            temp = x;
             Thread.Sleep(60); 
          }
        }
