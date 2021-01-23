    internal class VerticalPanel : Panel {
      private int space = 10;
      public int Space {
        get { return space; }
        set {
          space = value;
          LayoutControls();
        }
      }
      protected override void OnControlAdded(ControlEventArgs e) {
        base.OnControlAdded(e);
        LayoutControls();
      }
      protected override void OnControlRemoved(ControlEventArgs e) {
        base.OnControlRemoved(e);
        LayoutControls();
      }
      private void LayoutControls() {
        int height = space;
        foreach (Control c in base.Controls) {
          height += c.Height + space;
        }
        base.AutoScrollMinSize = new Size(0, height);
        int top = base.AutoScrollPosition.Y + space;
        int width = base.ClientSize.Width - (space * 2);
        foreach (Control c in base.Controls) {
          c.SetBounds(space, top, width, c.Height);
          c.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
          top += c.Height + space;
        }
      }
    }
