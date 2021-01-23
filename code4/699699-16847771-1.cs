    public class MainViewModel : ViewModelBase {
        
        // When the ViewModel is created, populate _selectedAdventurer
        // with an empty Adventurer so that your form has something to  
        // bind to (and it can also be used as a "New" adventurer)
        private Adventurer _selectedAdventurer = new Adventurer();
        public string FirstName {
            get {
                return _selectedAdventurer.FirstName;
            }
            set {
                _selectedAdventurer.FirstName = value;
                // The following is implemented in our fictional
                // ViewModelBase, and essentially raises a notification
                // event to WPF letting it know that FirstName has changed
                OnPropertyChanged("FirstName");
            }
        }
        /*
           The remaining properties are implemented in a similar fashion, and in 
           this simple case are mainly acting as passthroughs to the view plus 
           a little bit of binding code
        */
        // These methods will house your save/load logic. I will assume
        // for simplicity that you already know how to wrap this logic in a
        // Command that can be bound to the view
        public void SaveAdventurer() {
           if(_selectedAdventurer != null) {
               SerializeToFile(_selectedAdventurer);
           }
        }
        public void LoadAdventurer() {
           _selectedAdventurer = LoadFromFile();
        }
        private void SerializeToFile(Adventurer adventurer) {
           // Use your serializer and save to file
        }
        private Adventurer LoadFromFile() {
           // Load from file and deserialize into Adventurer
        }
        
    }
