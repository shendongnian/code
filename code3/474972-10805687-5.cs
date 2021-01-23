    public class MyCombo : ComboBox {
      public MyCombo() {
        this.DropDownStyle = ComboBoxStyle.DropDownList;
        this.DrawMode = DrawMode.OwnerDrawFixed;
      }
      protected override void OnDrawItem(DrawItemEventArgs e) {
        if (e.Index > -1) {
          int startX = e.Bounds.Left + 5;
          int startY = (e.Bounds.Y + e.Bounds.Height / 2);
          int endX = e.Bounds.Right - 5;
          int endY = (e.Bounds.Y + e.Bounds.Height / 2);
          using (Pen p = new Pen(Color.Blue, (Int32)this.Items[e.Index])) {
            e.Graphics.DrawLine(p, new Point(startX, startY), new Point(endX, endY));
          }
        }
        base.OnDrawItem(e);
      }
    }
