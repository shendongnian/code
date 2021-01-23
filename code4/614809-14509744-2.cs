    public class VirtualTreeView : UserControl {
      protected override void OnKeyDown(KeyEventArgs e) {
        if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.PageUp || e.KeyCode == Keys.PageDown || e.KeyCode == Keys.Home || e.KeyCode == Keys.End) {
          if (e.Control) {
            MessageBox.Show("Ctrl - " + e.KeyCode.ToString());
          }
        } else
          base.OnKeyDown(e);
      }
      protected override bool IsInputKey(Keys keyData) {
        // Capture arrow keys
        if ((keyData & (Keys.Up | Keys.Down | Keys.Left | Keys.Right | Keys.PageDown | Keys.PageUp | Keys.ControlKey | Keys.Control)) != 0)
          return true;
        else
          return base.IsInputKey(keyData);
      }
    }
