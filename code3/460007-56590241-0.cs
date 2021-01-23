    public Constructor()
    {
      InitializeComponent(); 
      this.SampleDataGrid.PreviewKeyDown += MoveCellOnEnterKey;
    }
    
    private void MoveCellOnEnterKey(object sender, KeyEventArgs e)
    {
      if(e.Key == Key.Enter)
      {
        // Cancel [Enter] key event.
        e.Handled = true;
        // Press [Tab] key programatically.
        var tabKeyEvent = new KeyEventArgs(
          e.KeyboardDevice, e.InputSource, e.Timestamp, Key.Tab);
        tabKeyEvent.RoutedEvent = Keyboard.KeyDownEvent;
        InputManager.Current.ProcessInput(tabKeyEvent);
      }
    }
