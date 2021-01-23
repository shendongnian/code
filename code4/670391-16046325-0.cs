    public class TestControl : Control {
      Button button;
      public TestControl() {
        button = new Button() { Text = "Click" };
        this.Controls.Add(button);
      }
      public bool ButtonVisible {
        get { return button.Visible; }
        set {
          button.Visible = value;
        }
      }
    }
