    public partial class Form2 : Form
    {
        private const float LARGER_FONT_FACTOR = 1.5f;
        private const float SMALLER_FONT_FACTOR = 0.8f;
        private int _lastFormSize;
        public Form2()
        {
            InitializeComponent();
            this.Resize += new EventHandler(Form2_Resize);
            _lastFormSize = GetFormArea(this.Size);
        }
        private int GetFormArea(Size size)
        {
            return size.Height * size.Width;
        }
        private void Form2_Resize(object sender, EventArgs e)
        {
            var bigger = GetFormArea(this.Size) > _lastFormSize;
            float scaleFactor = bigger ? LARGER_FONT_FACTOR : SMALLER_FONT_FACTOR;
            ResizeFont(this.Controls, scaleFactor);
            _lastFormSize = GetFormArea(this.Size);
        }
        private void ResizeFont(Control.ControlCollection coll, float scaleFactor)
        {
            foreach (Control c in coll)
            {
                if (c.HasChildren)
                {
                    ResizeFont(c.Controls, scaleFactor);
                }
                else
                {
                    //if (c.GetType().ToString() == "System.Windows.Form.Label")
                    if (true)
                    {
                        // scale font
                        c.Font = new Font(c.Font.FontFamily.Name, c.Font.Size * scaleFactor);
                    }
                }
            }
        }
    }
}
