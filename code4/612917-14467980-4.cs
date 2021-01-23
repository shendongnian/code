    public class TestUserControlViewModel : BaseViewModel {
        private string id;
        private string someOtherData;
        public TestUserControlViewModel() {
            DataItem firstItem = new DataRepository().GetData().First();
            this.ID = firstItem.ID;
            this.SomeOtherData = firstItem.SomeOtherData;
        }
        public string ID {
            get {
                return this.id;
            }
            set {
                if (this.id == value) return;
                this.id = value;
                this.OnPropertyChangedEvent("ID");
            }
        }
        public string SomeOtherData {
            get {
                return this.someOtherData;
            }
            set {
                if (this.someOtherData == value) return;
                this.someOtherData = value;
                this.OnPropertyChangedEvent("SomeOtherData");
            }
        }
    }
