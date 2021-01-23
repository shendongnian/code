    public class TestUserControlViewModel : BaseViewModel
        private ObservableCollection<DataItem> allData;
        public TestUserControlViewModel() {
             IGetTheData src = new DataRepository();
             this.allData = new ObservableCollection<DataItem>(src.GetData());
        }
        public ObservableCollection<DataItem> AllData {
            get {
                return this.allData;
            }
        }
        public void AddDataItem(DataItem item) {
            this.allData.Add(item);
        }
    }
