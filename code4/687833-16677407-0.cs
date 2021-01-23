    public class CustomDropBox : Control {
      private ListBox box = new ListBox() { IntegralHeight = false };
      private ToolStripControlHost host;
      private ToolStripDropDown drop;
      private bool wasShowing = false;
      public CustomDropBox() {
        box.MinimumSize = new Size(120, 120);
        box.MouseUp += box_MouseUp;
        box.KeyPress += box_KeyPress;
        box.Items.AddRange(new string[] { "aaa", "bbb", "ccc" });
        host = new ToolStripControlHost(box) { Padding = Padding.Empty };
        drop = new ToolStripDropDown() { Padding = Padding.Empty };
        drop.Closing += drop_Closing;
        drop.Items.Add(host);
      }
      private Rectangle GetDownRectangle() {
        return new Rectangle(this.ClientSize.Width - 16, 0, 16, this.ClientSize.Height);
      }
      void drop_Closing(object sender, ToolStripDropDownClosingEventArgs e) {
        if (e.CloseReason == ToolStripDropDownCloseReason.AppClicked) {
          wasShowing = GetDownRectangle().Contains(this.PointToClient(Cursor.Position));
        } else {
          wasShowing = false;
        }
      }
      void box_KeyPress(object sender, KeyPressEventArgs e) {
        if (e.KeyChar == (char)Keys.Enter && box.SelectedIndex > -1) {
          drop.Close();
        }
      }
      void box_MouseUp(object sender, MouseEventArgs e) {
        int index = box.IndexFromPoint(e.Location);
        if (index > -1) {
          drop.Close();
        }
      }
      protected override void OnMouseDown(MouseEventArgs e) {
        if (e.Button == MouseButtons.Left && GetDownRectangle().Contains(e.Location)) {
          if (wasShowing) {
            wasShowing = false;
          } else {
            drop.Show(this, new Point(0, this.Height));
          }
        }      
        base.OnMouseDown(e);
      }
      protected override void OnPaint(PaintEventArgs e) {
        e.Graphics.Clear(Color.White);
        ControlPaint.DrawComboButton(e.Graphics, GetDownRectangle(), ButtonState.Normal);
        base.OnPaint(e);
      }
    }
