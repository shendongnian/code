    namespace WpfApplication18
    {
        public partial class MainWindow
        {
            public MainWindow()
            {
                InitializeComponent();
                //SetupPersonsVM();
                SetupSpecificPersonsVM();
            }
            private void SetupSpecificPersonsVM()
            {
                var vm = new SpecificPersonsVM();
                vm.Items.Add(new SpecificPersonVM { FirstName = "Johny", LastName = "Bravo", Age = 17 });
                vm.Items.Add(new SpecificPersonVM { FirstName = "Dude", LastName = "Gray", Age = 22 });
                vm.Items.Add(new SpecificPersonVM { FirstName = "Scott", LastName = "Thomas", Age = 34 });
                DataContext = vm;
            }
            private void SetupPersonsVM()
            {
                var vm = new PersonsVM();
                vm.Items.Add(new PersonVM { FirstName = "John", LastName = "Scott" });
                vm.Items.Add(new PersonVM { FirstName = "Matthew", LastName = "Johnson" });
                DataContext = vm;
            }
        }
    }
