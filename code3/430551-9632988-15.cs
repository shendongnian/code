    public class Controller : IController
    {
        public Controller(IView view, IFileSaver fileSaver)
        {
            view.AddButtonClickHandler(() => view.DisplayMessage(fileSaver.SaveFileWithRandomLine() ? "It worked!" : "It failed!"));
        }
    }
