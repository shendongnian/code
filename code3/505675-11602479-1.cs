     public class MyTextBox : TextBox
        {
    
            public MyTextBox()
            {
                SetStyle(ControlStyles.UserPaint, true);
            }
         protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            this.Invalidate();
        }
    
            protected override void OnPaint(PaintEventArgs e)
            {
     e.Graphics.DrawString(this.Text, this.Font, new SolidBrush(Color.Black), new System.Drawing.RectangleF(0, 0, this.Width , this.Height ), System.Drawing.StringFormat.GenericDefault);
                e.Graphics.DrawString("Lloyd", this.Font, new SolidBrush(Color.Red), new System.Drawing.RectangleF(0, 0, 100, 100), System.Drawing.StringFormat.GenericTypographic);
                base.OnPaint(e);
            }
        }
