    public class GradientLabel : Label {
        protected override void OnPaint(PaintEventArgs e) {
            e.Graphics.FillRectangle(new LinearGradientBrush(new Point(0, 0), new Point(0, this.Height), this.ForeColor, this.BackColor), ClientRectangle);
        }
    }
