    public class mainForm : IMainForm {
      // This method is defined in the interface, so mainForm
      // must implement it.
      public string GetStringFromMainForm() {
        return "Hello from MainForm";
      }
      public void CreatePanel() {
        // pass in a reference to myself so panel knows how to
        // talk to me.
        var panel = new Panel(this);
      }
    }
