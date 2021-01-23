    using System.Linq;
    using BaseWPFFramework.MVVM;
    using System.Collections.ObjectModel;
    
    namespace WpfApplication4
    {
        public partial class Window11
        {
            public Window11()
            {
                InitializeComponent();
                DataContext = new ListViewModel();
            }
        }
    }
