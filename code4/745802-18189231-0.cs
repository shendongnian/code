    public MainWindow()
          {
             InitializeComponent();
             Scroller.ManipulationStarted += new EventHandler<ManipulationStartedEventArgs>(scroller_ManipulationStarted);
             Scroller.ManipulationMode = ManipulationMode.Control; // Required
          }
    
          void scroller_ManipulationStarted(object sender, ManipulationStartedEventArgs e)
          {
             if (locked)
             {
                e.Handled = true;
                e.Complete();
             }
          }
