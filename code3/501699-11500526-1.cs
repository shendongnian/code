    bool button2Clicked = false;
    private void Form1_Load(object sender, EventArgs e)
    {    
        // A good Way to call Thread
        System.Threading.Thread t1 = new System.Threading.Thread(delegate()
        {
           while (!button2Clicked)
           {
              // Do Any Stuff;
              System.Threading.Thread.Sleep(60000);  //60000 Millieconds=1M
           }
        });
        t1.IsBackground = true;  // With above statement Thread Will automatically
        // be Aborted on Application Exit
        t1.Start();
    }
