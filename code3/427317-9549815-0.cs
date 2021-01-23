    public partial class Page2
    {
        public Page2()
        {
            InitializeComponent();
            DataContext = new List<ViewModel>
                              {
                                  new ViewModel()
                              };
        }
    }
    public class ViewModel : ViewModelBase
    {
        private bool _combiBanksSelected;
        public bool CombiBanksSelected
        {
            get { return _combiBanksSelected; }
            set
            {
                Set(()=>CombiBanksSelected, ref _combiBanksSelected, value);
            }
        }
    }
