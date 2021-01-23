    public interface IDialogService
    {
        public void Inform(string message);
        public bool AskYesNoQuestion(string question, string title);
    }
