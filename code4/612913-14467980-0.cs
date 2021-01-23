    public class TestUserControlViewModel : BaseViewModel
        private ObservableCollection<DataItem> getAllData;
        public TestUserControlViewModel() {
             IGetTheData src = new DataRepository();
             this.getAllData = new ObservableCollection<DataItem>(src.GetData());
        }
        public ObservableCollection<DataItem> GetAllData {
            get {
                return this.getAllData;
            }
        }
        public void AddDataItem(DataItem item) {
            this.getAllData.Add(item);
        }
    }
