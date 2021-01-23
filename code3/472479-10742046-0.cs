    public class ExampleViewmodel : ViewModel
    {
          private IConfirmDialogManager _dialogManager;
          public ExampleViewmodel(IConfirmDialogManager dialog)
          {
                _dialogManager = dialog;
          }
          // ... code happens ...
          private void DeleteCommand()
          {
                 bool result = _dialogManager.Confirm("Are you sure you want to delete?");
          }
    }
