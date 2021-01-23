    public class SomeClass : ViewModelBase {
       public ICommand ConnectButtonCommand { get; }
       public SomeClass(){
          //...
          ConnectButtonCommand = new DelegateCommand(ConnectButton_Click, ConnectButton_CanExecute);
          //...
       }
       public DoSomething(){
          //do something that affects the result of ConnectButton_CanExecute
          ((DelegateCommand)ConnectButtonCommand).RaiseCanExecuteChanged();
       }
       private void ConnectButton_Click() {/*...*/}
       private bool ConnectButton_CanExecute() {/*...*/}
    }
