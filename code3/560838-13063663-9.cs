       namespace WpfApplication1
        {
            /// <summary>
            /// Interaction logic for MainWindow1.xaml
            /// </summary>
            public partial class MainWindow1 : Window
            {
                RBViewModel _viewModel;
                public MainWindow1()
                {
                    InitializeComponent();
                    _viewModel = (RBViewModel)base.DataContext;
            
                    for (int i = 0; i < 4; i++)
                    {
                         _viewModel.Rbs.Add(new RBVM() {RadioBase="a"+i, BaseCheck=true });
                    }
                }
                private void test_Click(object sender, RoutedEventArgs e)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        _viewModel.Rbs[i].BaseCheck = false;
                    }
                }
            }
        }
