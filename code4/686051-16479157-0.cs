    public interface IViewService
    {
       //show message dialog with message text
       void ShowMessageDialog(string message);
       //show Yes/No message dialog with message text. Retrun true if answer is Yes 
       bool AskQuestion(string message);
       //Navigate to some other viewmodel
       void NavigateTo(ViewModel someOtherViewModel);      
    }
