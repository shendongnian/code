    public partial class DialogWindow : Window
    {
        public DialogWindow()
        {
            ViewModel vm = new ViewModel();
            this.DataContext = vm;
            vm.CloseAction = new Action(() => this.Close());
        }
    }
