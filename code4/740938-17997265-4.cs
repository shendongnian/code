    namespace WpfApplication1
    {
        using System.Windows;
        using System.Windows.Controls;
    
        public partial class UserControl1: UserControl
        {
            public UserControl1()
            {
                DataContext = new UserControl1ViewModel();
                InitializeComponent();
            }
        }
    }
