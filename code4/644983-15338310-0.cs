     public partial class MainWindow : Window
        {
            bool test = false;
            public MainWindow()
            {
                InitializeComponent();
    
                MenuItem_Click(myYouTube, null);
            }
    
            private void MenuItem_Click(object sender, RoutedEventArgs e)
            {
                var mymenuitem = sender as MenuItem;
    
                MenuItem menu = (MenuItem)sender;
                ItemCollection items = menu.Items;
                items.Clear();
    
                if (test)
                {
                    MenuItem refreshItem = new MenuItem();
                    refreshItem.Header = "Refresh";
                    //refreshItem.Click += DidPressRefresh;
                    items.Add(refreshItem);
    
                    MenuItem logouttItem = new MenuItem();
                    logouttItem.Header = "Signout";
                    //logouttItem.Click += DidPressLogout;
                    items.Add(logouttItem);
    
    
                    test = false;
                }
                else
                {
                    MenuItem loginItem = new MenuItem();
                    loginItem.Header = "Login";
                    //loginItem.Click += DidPressLogin;
                    items.Add(loginItem);
    
                    test = true;
                }
            }
        }
