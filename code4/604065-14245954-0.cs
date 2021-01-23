    public class ToolStripMenuItemEx : ToolStripMenuItem {
      protected override bool ProcessCmdKey(ref Message m, Keys keyData) {
        if (keyData == Keys.Escape) {
          ToolStripDropDownButton tb = this.OwnerItem as ToolStripDropDownButton;
          if (tb != null) {
            tb.HideDropDown();          
            return true;
          }
        }
        return base.ProcessCmdKey(ref m, keyData);
      }
    }
