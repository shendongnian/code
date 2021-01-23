    public class MainViewModel
    {
      private readonly ObservableCollection<TreeItemViewModel> internalChildrens;
    
      public MainViewModel(string topLevelHeader) {
        this.TopLevelHeader = topLevelHeader;
        this.internalChildrens = new ObservableCollection<TreeItemViewModel>();
        var collView = CollectionViewSource.GetDefaultView(this.internalChildrens);
        collView.SortDescriptions.Add(new SortDescription("Header", ListSortDirection.Ascending));
        this.Childrens = collView;
      }
    
      public string TopLevelHeader { get; set; }
    
      public IEnumerable Childrens { get; set; }
    
      public bool AddNewChildren(double num) {
        var numExists = this.internalChildrens.FirstOrDefault(c => c.Header == num) != null;
        if (!numExists) {
          this.internalChildrens.Add(new TreeItemViewModel() {Header = num});
        }
        return numExists;
      }
    }
    
    public class TreeItemViewModel
    {
      public double Header { get; set; }
    }
