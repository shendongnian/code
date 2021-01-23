    public class MyTextBox : TextBox
    {
        public MyTextBox() : base()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, false); 
        }
    }
