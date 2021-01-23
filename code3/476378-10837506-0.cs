    class ViewModel {
        public event EventHandler ChangeDataRootPath;
    }
    
    class View : Window {
        public View() {
            InitializeComponent();
    
            var vm = new ViewModel();
            vm.ChangeDataRootPath += (s, e) => {
                Window window = new Window {
                    Content = new ChangeDataRootPathUserControl {
                        DataContext = vm
                    }
                };
                window.ShowDialog(); 
            };
            DataContext = vm;
        }
    }
