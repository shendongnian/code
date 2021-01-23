    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
    
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var ObserControl = new ObservableCollection<string>() { "Textbox", "Button" };
            GridViewControl.ItemsSource = ObserControl;
        }
    
        private void Form_Drop(object sender, DragEventArgs e)
        {
            object sourceItem;
            e.Data.Properties.TryGetValue("Item", out sourceItem);
            double XPos = e.GetPosition(GridViewControl).X - 160;
            double YPos = e.GetPosition(GridViewControl).Y;
            if (sourceItem.ToString() == "Textbox")
            {
                var newTextbox = new TextBox();
                newTextbox.Text = "Textbox";
                newTextbox.SetValue(Canvas.LeftProperty, XPos);
                newTextbox.SetValue(Canvas.TopProperty, YPos);
                Form.Children.Add(newTextbox);
            }
            if (sourceItem.ToString() == "Button")
            {
                var newButton = new Button();
                newButton.Content = "Button";
                newButton.SetValue(Canvas.LeftProperty, XPos);
                newButton.SetValue(Canvas.TopProperty, YPos);
                Form.Children.Add(newButton);
            }
        }
    
        private void GridViewControl_DragItemsStarting(object sender, DragItemsStartingEventArgs e)
        {
            var item = e.Items.FirstOrDefault();
            e.Data.Properties.Add("Item", item);
        }
    }
