        private Dictionary<Button, System.Threading.Timer> buttonTimers = new Dictionary<Button, System.Threading.Timer>();
        public MainWindow()
        {
            InitializeComponent();
        }
        private void HoverTime(object state)
        {
            var thisButton = state as Button;
            thisButton.Dispatcher.BeginInvoke((Action)delegate()
            {
                thisButton.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            });
        }
        private void HoverButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            myTextBox.Text += "Delayed hover: " + button.Content + Environment.NewLine;
        }
        private void HoverButton_MouseEnter(object sender, MouseEventArgs e)
        {
            var thisButton = sender as Button;
            var t = new System.Threading.Timer(new TimerCallback(HoverTime), sender, 2500, Timeout.Infinite);
            buttonTimers.Add(thisButton, t);
        }
        private void HoverButton_MouseLeave(object sender, MouseEventArgs e)
        {
            var thisButton = sender as Button;
            if (buttonTimers.ContainsKey(thisButton))
            {
                buttonTimers[thisButton].Dispose();
                buttonTimers.Remove(thisButton);
            }
        }
