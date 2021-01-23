    public class MyData
    {
        public string Title { get; set; }
    }
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.DataContext = await LoadData();
        }
        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            SaveData(this.DataContext as MyData);
            base.OnNavigatedFrom(e);
        }
        private async Task<MyData> LoadData()
        {
            var _Data = await StorageHelper.ReadFileAsync<MyData>(
                this.GetType().ToString(), StorageHelper.StorageStrategies.Local);
            return _Data ?? new MyData() { Title = "Welcome" };
        }
        private async void SaveData(MyData data)
        {
            await StorageHelper.WriteFileAsync(
                this.GetType().ToString(), data, StorageHelper.StorageStrategies.Local);
        }
    }
