    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
            if (App.IsRunningOOBWithPermission)
            {
                txtInfo.Text = "You are running outside Browser Window.";
            }
            else
            {
                txtInfo.Text = "You are running inside Browser Window.";
            }
        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var cultrue = (e.AddedItems[0] as ComboBoxItem).Content.ToString();
            try
            {
                Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(cultrue);
                var res = App.Current.Resources["resxWrapper"] as ResourceMock;
                res.firePropertyChanged("Title");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        
    }
