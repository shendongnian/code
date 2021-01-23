    public class EditPersonCommand : ICommand
    {
      public bool CanExecute(object parameter)
      {
         PersonModel p = parameter as PersonModel;
         return p != null && p.Age > 0;
      }
      public event EventHandler CanExecuteChanged;
      public void Execute(object parameter) 
      {
          //command implementation
      }
      public void RaiseCanExecuteChanged()
      {
          var handler = CanExecuteChanged;
          if(handler != null)
          {
              handler(this, EventArgs.Empty);
          }
      }
    }
