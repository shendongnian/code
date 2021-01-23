    public partial class MainWindow : Window
	{
		public ViewModel ViewModel { get; set; }
		public MainWindow()
		{
			ViewModel = new ViewModel();
			InitializeComponent();			
		}
        }
    public class ViewModel : INotifyPropertyChanged
	{
		private DelegateCommand _someCmd;
		private bool _isRenaming;
		public DelegateCommand SomeCommand
		{
			get
			{
				return _someCmd ?? (_someCmd = new DelegateCommand(() =>
				                                                   	{
				                                                   		IsRenaming = true;
				                                                   	}));
			}
		}
		
		public bool IsRenaming
		{
			get { return _isRenaming; }
			set
			{
				_isRenaming = value;
				RaisePropertyChanged("IsRenaming");
			}
		}
          }
    
