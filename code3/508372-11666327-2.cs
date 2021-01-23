         public interface IViewModel
    {
    }
    
    public interface IView
    {
        IViewModel ViewModel
        {
            get;
            set;
        }
    }
    
    public interface ITiersView : IView
    {
    }
        //My View
        public partial class Tiers : UserControl , ITiersView
        {
            public Tiers(ITiersViewModel tiersViewModel)
            {
                InitializeComponent();
                ViewModel = tiersViewModel;
            }
    
            public SmartStock.Infrastructure.IViewModel ViewModel
            {
                get
                {
                    return (ITiersViewModel)DataContext;
                }
                set
                {
                    DataContext = value;
                }
            }
        }
