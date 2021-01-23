    public class ActionsViewModel: PropertyChangedBase
    {
        public ObservableCollection<ActionItem> AvailableActions { get; set; } 
        public ObservableCollection<ActionItem> SelectedActions { get; set; } 
        public ActionItem FocusedAction1 { get; set; }
        public ActionItem FocusedAction2 { get; set; }
        private string _result;
        public string Result
        {
            get { return _result; }
            set
            {
                _result = value;
                OnPropertyChanged("Result");
            }
        }
        public ActionsViewModel()
        {
            AvailableActions = new ObservableCollection<ActionItem>
                                    {
                                        new ActionItem() {DisplayName = "Introduction", Action = () => Result += " Hello there!"},
                                        new ActionItem() {DisplayName = "Greeting", Action = () => Result += " How are you today?"},
                                        new ActionItem() {DisplayName = "Story", Action = () => Result += " I once met a goat and his name was billy, and he lived on a plain that was very hilly."},
                                        new ActionItem() {DisplayName = "My Name", Action = () => Result += "My name is too infinity!"},
                                        new ActionItem() {DisplayName = "Conclusion", Action = () => Result += "That is all, goodbye!"}
                                    };
            SelectedActions = new ObservableCollection<ActionItem>();
        }
        public void AddAction()
        {
            var focused = FocusedAction1;
            
            if (focused != null)
            {
                AvailableActions.Remove(focused);
                SelectedActions.Add(focused);
            }
        }
        public void DeleteAction()
        {
            var focused = FocusedAction2;
            if (focused != null)
            {
                SelectedActions.Remove(focused);
                AvailableActions.Add(focused);
            }
        }
        public void Run()
        {
            Result = string.Empty;
            SelectedActions.ToList().ForEach(x => x.Action());
        }
    }
