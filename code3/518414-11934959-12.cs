    public class ViewModel : ViewModelBase
    {
        public ViewModel()
        {
            this.selectedNodeDoubleClickedCommand = new RelayCommand<Node>(node => 
            {
                Debug.WriteLine(String.Format("{0} clicked!", node.Text));
            });
        }
    
        public ObservableCollection<Node> Nodes { get; set; }
    
        public RelayCommand<Node> SelectedNodeDoubleClickedCommand
        {
            get { return selectedNodeDoubleClickedCommand; }
        }
        private readonly RelayCommand<Node> selectedNodeDoubleClickedCommand;
    }
