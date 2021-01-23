    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }
        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            string[] lstDays = new string[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
            //Creating a ListBox
            ListBox lstBox = new ListBox();
            foreach (string item in lstDays)
            {
                //Grid definition
                Grid mygrid = new Grid();
                mygrid.Width = 400;
                ColumnDefinition c1 = new ColumnDefinition(); //creating a column
                c1.Width = new GridLength(200);
                mygrid.ColumnDefinitions.Add(c1);
                TextBlock txtDays = new TextBlock(); //Creating a TextBlock
                RowDefinition r1 = new RowDefinition(); //Creating a row
                mygrid.RowDefinitions.Add(r1);
                
                txtDays.Text = item;
                txtDays.TextAlignment = TextAlignment.Left;
                if (item == "Thursday")
                {
                    txtDays.TextAlignment = TextAlignment.Right;
                    txtDays.Foreground = new SolidColorBrush(Colors.Green);
                }
                mygrid.Children.Add(txtDays); //Adding the TextBlock into the grid
                Grid.SetRow(txtDays,0);       //Placing the item in a particular row inside the grid          
                lstBox.Items.Add(mygrid);     //Placing grid inside a listBox    
            }
            RowDefinition rNewRow = new RowDefinition();
            ContentPanel.RowDefinitions.Add(rNewRow);
            ContentPanel.Children.Add(lstBox);
        }
    }
