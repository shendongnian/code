    using System.Windows;
    public partial class SomeDialog : Window
    {
        public SomeDialog()
        {
            var vm = new ViewModel();
            DataContext = vm;
            CommandBindings.AddRange(vm.Commands);
            InitializeComponent();
        }
     }
