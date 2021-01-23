    public class DialogService
    {
        public void Inform(string message)
        {
            MessageBox.Show(message);
        }
        public bool AskYesNoQuestion(string question)
        {
            return MessageBox.Show(question, title, MessageBoxButton.YesNo) ==         
                       MessageBoxResult.Yes
        }
    }
