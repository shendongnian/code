    public partial class SearchField : UserControl
    {
       public SearchField()
       {
           InitializeComponent();
    
           this.Loaded += (s, e) => this.LayoutRoot.DataContext = new SearchFieldViewModel();
        }
    }
