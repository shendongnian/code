    public class ItemViewModel : INotifyPropertyChanged {
        private Item model;
        public ItemViewModel(Item item) {
            model = item;
            item.PropertyChanged += (o,e) => onPropertyChanged(e.Property);
        }
        public bool IsSelected { get; set; }
        public string Name {
            get { return model.Name; }
            set { model.Name = value; }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void onPropertyChanged(string property) {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) {
                handler(this, new PropertyChangedEventArgs(property));
            }
        }
    }
    public sealed class Item : INotifyPropertyChanged {
        private string name;
        public string Name {
            get { return name; }
            set {
                if (name != value) {
                    name = value;
                    onPropertyChanged("Name");
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void onPropertyChanged(string property) {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) {
                handler(this, new PropertyChangedEventArgs(property));
            }
        }
    }
