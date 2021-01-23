    public partial class MainPage : PhoneApplicationPage
    {
        public static MobileServiceClient MobileService = new MobileServiceClient(
            "https://YOUR-APP-NAME.azure-mobile.net/",
            "YOUR-APPLICATION-KEY"
        );
        
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }
        private async void btnStart_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var table = MobileService.GetTable<Test>();
                var item = new Test
                {
                    name = "Header Text \n• Item \n• Item \n• Item \n Header \n• Item"
                };
                await table.InsertAsync(item);
                var inserted = await table.LookupAsync(item.id);
                this.txtDebug.Text = inserted.name;
            }
            catch (Exception ex)
            {
                this.txtDebug.Text = ex.ToString();
            }
        }
    }
    public class Test
    {
        public int id { get; set; }
        public string name { get; set; }
    }
