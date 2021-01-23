    public class MySplit : SplitContainer {
      public MySplit() {
        this.SetStyle(ControlStyles.Selectable, false);
      }
      protected override void OnPaint(PaintEventArgs e) {
        e.Graphics.Clear(Color.Red);
      }
    }
