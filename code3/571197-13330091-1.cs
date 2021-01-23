    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            var pnl = new StackPanel();
            this.Content = pnl;
            var button = new Button();
            button.Content = "Hi";
            pnl.Children.Add(button);
            SetBorder(button);
        }
        public void SetBorder(FrameworkElement fe)
        {
            var borderControl = fe as Control;
            if (borderControl != null)
            {
                borderControl.BorderThickness = new Thickness(10);
                borderControl.BorderBrush = Brushes.Red;
            }
        }
    }
