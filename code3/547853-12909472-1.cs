    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            LoadData();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }
        ObservableCollection<KiwiItem> sourceColl;
        IList<KiwiItem> selectionList;
        public void LoadData()
        {
            var dbPath = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "db.sqlite");
            
            // Exec (1)
            using (var db = new SQLite.SQLiteConnection(dbPath))
            {
                db.DropTable<KiwiItem>();
                db.CreateTable<KiwiItem>();
                db.RunInTransaction(() =>
                {
                    db.Insert(new KiwiItem() { ID = 1, Title = "MyTitle1" });
                    db.Insert(new KiwiItem() { ID = 2, Title = "MyTitle2" });
                    db.Insert(new KiwiItem() { ID = 3, Title = "MyTitle3" });
                    db.Insert(new KiwiItem() { ID = 4, Title = "MyTitle4" });
                });
                this.sourceColl = new ObservableCollection<KiwiItem>();
                this.selectionList = new List<KiwiItem>();
                // Query the db. In practice, fill the sourceColl according to your business scenario
                foreach (KiwiItem item in db.Table<KiwiItem>())
                {
                    this.sourceColl.Add(item);
                    if (item.ID == 2 || item.ID == 4)
                        this.selectionList.Add(item);
                }
            }
            // Exec (2)
            this.listView.ItemsSource = this.sourceColl;
            foreach (KiwiItem item in this.selectionList)
                this.listView.SelectedItems.Add(item);
        }
    }
    public class KiwiItem
    {
        [SQLite.AutoIncrement, SQLite.PrimaryKey]
        public int ID { get; set; }
        public string Title { get; set; }
    }
