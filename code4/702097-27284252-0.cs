    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
            FillDataGrid();
        }
        private void FillDataGrid()
        {
            Service1Client client = new Service1Client();
            client.GetAllEmpCompleted += new
                EventHandler<GetAllEmpCompletedEventArgs>(client_GetAllEmpCompleted);
            client.GetAllEmpAsync();
        }
        void client_GetAllEmpCompleted(object sender, GetAllEmpCompletedEventArgs e)
        {
            GridTest.ItemsSource = e.Result;
        }
    }
