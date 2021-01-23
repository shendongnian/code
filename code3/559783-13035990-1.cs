      public UserControl1()
            {
                InitializeComponent();
                ClickHereCommand = new RoutedCommand();
                CommandBindings.Add(new CommandBinding(ClickHereCommand, ClickHereExecuted));
                ButtonContent = "Click Here";
                this.DataContext = this;
            }
