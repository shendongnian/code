    public Window1()
    {
      InitializeComponent();
    
      CheckBox myCheckBox = new CheckBox();
      myCheckBox.Content = "A Checkbox";
    
      System.Threading.Thread thread = new System.Threading.Thread(
        new System.Threading.ThreadStart(
          delegate()
          {
            System.Windows.Threading.DispatcherOperation
              dispatcherOp = myCheckBox.Dispatcher.BeginInvoke(
              System.Windows.Threading.DispatcherPriority.Normal,
              new Action(
                delegate()
                {
                  myCheckBox.IsChecked = true;
                }
            ));
    
            dispatcherOp.Completed += new EventHandler(dispatcherOp_Completed);
          }
      ));
    
      thread.Start();
    }
    
    void dispatcherOp_Completed(object sender, EventArgs e)
    {
      Console.WriteLine("The checkbox has finished being updated!");
    }
