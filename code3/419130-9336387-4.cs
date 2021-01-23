     var outsideThread = new Thread(()=>
     {         
         for(int i = 0; i < 20; i++)
              {
                  //This code will show all at once since it is on the main thread, 
                  //which is still running
                  //If you want this to display one at a time also, then you need
                  //to use threads and callbacks like below, also
                  Dispatcher.BeginInvoke(()=>{textBlock1.Text += "outer" + i;});
                  int newI = i;
                  var thread = new Thread(() =>
                  {
                      System.Threading.Thread.Sleep(1000 * newI);
                      Dispatcher.BeginInvoke(() =>
                      {
                          //This will display as it comes in
                          textBlock1.Text += "inner" + newI;
                      });
                  });
                  thread.Start();
              }
    });
    outsideThread.Start();
