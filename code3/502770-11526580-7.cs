    class ViewModel {
        // ...
        public DelegateCommand<object> FooCommand { get; set; }
        public ViewModel () {
            FooCommand = new DelegateCommand<object>(CanExecuteFooCommand, ExecuteFooCommand);
        }
        public bool CanExecuteFooCommand (object param) {
            return true;
        }
        public void ExecuteFooCommand (object param) {
            foo();
        }
        // ...
    }
