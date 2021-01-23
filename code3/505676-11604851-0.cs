    public class MyTextBox : TextBox
    {
        public const int WM_PAINT = 0x000F;
    
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_PAINT:
                    Invalidate();
                    base.WndProc(ref m);
                    if (!ContainsFocus && string.IsNullOrEmpty(Text))
                    {
                        Graphics gr = CreateGraphics();
                        StringFormat format = new StringFormat();
                        format.Alignment = StringAlignment.Far;
    
                        gr.DrawString("Enter your name", Font, new SolidBrush(Color.FromArgb(70, ForeColor)), ClientRectangle, format);
                    }
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }
    }
