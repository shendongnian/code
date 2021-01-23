    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        // Masters
        private List<string> _masters = new List<string>() { "Actions 0", "Actions 1" };
        public List<string> Masters { get { return _masters; } set { _masters = value; OnPropertyChanged("Masters"); } }
        // Action
        private int action;
        public int Action { get { return this.action; } set { action = value; PopulateActionList(); OnPropertyChanged("Action"); } }
        // ActionList
        private List<String> actionList;
        public List<String> ActionList { get { return actionList; } set { this.actionList = value; OnPropertyChanged("ActionList"); } }
        private void PopulateActionList()
        {
            if (this.action == 0)
                this.ActionList = new List<String> { "Chinese", "Indian", "Malay", "Indian" };
            else if (this.action == 1)
                this.ActionList = new List<String> { "Dog", "Cats", "Pigs", "Horses", "Fish", "Lion" };
        }
    }
