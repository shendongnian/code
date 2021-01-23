    public class Controller : IController
    {
        public Controller(IView view, IFileSaver fileSaver)
        {
            view.AddButtonClickHandler(() => view.Result = fileSaver.SaveFileWithRandomLine() ? "It worked!" : "It failed!");
        }
    }
