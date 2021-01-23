    public class NumericUpDownEx : NumericUpDown
    {
        bool isValid = true;
        int[] validValues = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (!isValid)
            {
                ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle, Color.Red, ButtonBorderStyle.Solid);
            }
        }
        protected override void OnValueChanged(System.EventArgs e)
        {
            base.OnValueChanged(e);
            isValid = validValues.Contains((int)this.Value);
            this.Invalidate();
        }
    }
