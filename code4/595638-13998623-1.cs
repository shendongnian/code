    public class TextBoxHeightAdjustable : System.Windows.Forms.TextBox
    {
        const int WM_DBLCLICK = 0xA3;
        const int WM_LBUTTONDBLCLK = 0x203;
        
        public TextBoxHeightAdjustable() : base()
        {
            this.AutoSize = false;
            this.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
        }
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            //base.OnKeyPress(e);
            if (e.KeyChar == (char)Keys.Back)
            {
                Text = Text.Remove(Text.Length-1);
            } 
            else
            {
                Text += e.KeyChar;
            }
            e.Handled = true;
        }
        protected override void WndProc(ref Message m)
        {
            if ((m.Msg == WM_DBLCLICK) || (m.Msg == WM_LBUTTONDBLCLK))
            {
            }
            else
            {
                base.WndProc(ref m);
            }
        }
        protected override void OnTextChanged(System.EventArgs args)
        {
            //KeyEventArgs kpe = (KeyEventArgs) args;
            //this.Font = new Font(this.Font.FontFamily, 0);
            using (Graphics g = this.CreateGraphics())
            {
                g.FillRectangle(Brushes.White, ClientRectangle);
                StringFormat stringFormat = new StringFormat();
                stringFormat.Alignment = StringAlignment.Center;
                stringFormat.LineAlignment = StringAlignment.Center;
                g.DrawString(Text, Font, new SolidBrush(ForeColor), ClientRectangle, stringFormat);
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            this.HideCaret();
            e.Graphics.FillRectangle(Brushes.White, ClientRectangle);
            // This never runs no matter what I try!
            //base.OnPaint(e);
            // Create a StringFormat object with the each line of text, and the block 
            // of text centered on the page.
            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;
            e.Graphics.DrawString(Text, Font, new SolidBrush(ForeColor), ClientRectangle, stringFormat);
        }
    }
