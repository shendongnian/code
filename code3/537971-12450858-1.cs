    public MainWindow() 
        { 
            InitializeComponent();
            this.SetToggleIcon(Properties.Settings.Default.toggleThis);
        } 
    
        private void Toggle()
        {
            this.StoreToggleState(!Properties.Settings.Default.toggleThis);
            this.SetToggleIcon(Properties.Settings.Default.toggleThis);
        }
        
        private void SetToggleIcon(bool state)
        {
          this.menuItem_ToggleSettings.Icon = (Properties.Settings.Default.toggleThis) ? Properties.Settings.Default.IconTrue : Properties.Settings.Default.IconFalse;
        }
    
        private void StoreToggleState(bool state)
        {
           Properties.Settings.Default.toggleThis = state;
           Properties.Settings.Default.Save();
        }
     
        private void MenuItem_Click(object sender, RoutedEventArgs e) 
        { 
          this.Toggle();
        }
