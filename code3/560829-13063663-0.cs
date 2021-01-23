     public MainWindow1()
            {
                InitializeComponent();
                RadioButton rb;
                for (int i = 0; i < 4; i++)
                {
                    rb = new RadioButton();
                    rb.SetBinding(RadioButton.ContentProperty, "RadioBase");
                    rb.SetBinding(RadioButton.IsCheckedProperty, "BaseCheck");
                    rb.GroupName = "Group";
                    rb.Margin = new Thickness(i * 10); //<-- Only to show quickly
                    main.Children.Add(rb);
                }
            
            }
