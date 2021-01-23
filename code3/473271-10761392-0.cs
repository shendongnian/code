    class YourForm : Form
    {
      private volatile MyEventArgs progress = null;
    
      private void buttonDoSomething_Click(object sender, EventArgs args)
      {
        var timewaster = new Worker_Class();
        timewaster.ProgressChanged += (sender, args) { progress = args; };
        Task.Factory.StartNew(
          () =>
          {
            timewaster.a_lengthy_task();
          }
        UpdateTimer.Enabled = true;
      }
    
      private void UpdateTimer_Tick(object sender, EventArgs args)
      {
        if (progress != null)
        {
          if (progress.IsFinished)
          {
            ShowInfo.Text = "Finished";
            UpdateTimer.Enabled = false;
          }
          else
          {
            ShowInfo.Text = progress.SaveNow.Value.ToString();
          }
        }
        else
        {
          ShowInfo.Text = "No progress yet";
        }
      }
    }
    class Worker_Class
    {
      public event EventHandler<MyEventArgs> ProgressChanged;
      public Worker_Class()
      {
        ProgressChanged += (sender, args) => { };
      }
    
      public void a_lengthy task()
      {
        int iteration = 0;
        while(iteration < 10)
        {
            Datetime saveNOW = Datetime.Now;
            Thread.sleep(10000);
            ProgressChanged(this, new MyEventArgs { SaveNow = saveNOW, IsFinished = false });
            iteration++
        }
        ProgressChanged(this, new MyEventArgs { SaveNow = null, IsFinished = true });
      }
    }
    class MyEventArgs : EventArgs
    {
      public DateTime? SaveNow { get; set; }
      public bool IsFinished { get; set; }
    }
