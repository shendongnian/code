    timer = 0;
    Console.WriteLine("timer start ");
    timer1.Start();
    
    private void timer1_Tick(object sender, EventArgs e)
    {
        Console.WriteLine(timer);
        if (++timer == 2) {
          Console.WriteLine("timer ends");
          // and you probably want a timer1.Stop() in here too
        }
    }
