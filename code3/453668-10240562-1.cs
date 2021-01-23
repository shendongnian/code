    public class Panel {
      // use a private variable to keep track of main form
      private IMainForm _mainForm;
      // Constructor: pass in a class that implements IMainForm. It isn't
      // a type of MainForm, so there's no dependency on the concrete class.
      public Panel(IMainForm mainForm) {
        _mainForm = mainForm;
      }
      public void TalkToMainForm() {
        var resultFromMainForm = _mainForm.GetStringFromMainForm();
        Console.WriteLine(resultFromMainForm);
      }
    }
