    public class TreeNodeViewModel
    {
        public TreeNodeViewModel()
        {
            Children = new ObservableCollection<TreeNodeViewModel>();
        }
        public bool IsExpanded { get; set; }
        public bool IsSelected { get; set; }
        public string Description { get; set; }
        public ObservableCollection<TreeNodeViewModel> Children { get; set; }
    }
