       public MainPage() {
          this.InitializeComponent();
          for (int i = 0; i < 4; i++)
          {
            RadioButton rad = new RadioButton();
            rad.HorizontalAlignment = HorizontalAlignment.Left;
            rad.VerticalAlignment = VerticalAlignment.Top;
            rad.Margin = new Thickness(100, i * 40, 0, 0);
            rad.Width = 350;
            rad.Height = 30;
            rad.GroupName = "group1";
            rad.IsEnabled = true;
            rad.Content = "Button " + i;
            rad.Checked += new RoutedEventHandler(radbtn);
            gridit.Children.Add(rad);
          }
    
        }
        void radbtn(object obj, RoutedEventArgs e) {
          edit_del_tb.Text = (obj as RadioButton).Content.ToString();
        }
