    public class DialogService
    {
        public void Inform(string message)
        {
            MessageBox.Show(message);
        }
        public void AskYesNoQuestion(string question)
        {
            return MessageBox.Show(question, title, MessageBoxButton.YesNo) ==         
                       MessageBoxResult.Yes
        }
    }
