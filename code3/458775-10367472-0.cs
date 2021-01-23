    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            listBox1.DrawMode = DrawMode.OwnerDrawFixed;
            listBox1.DrawItem += new DrawItemEventHandler(listBox1_DrawItem);
            listBox1.Items.AddRange(new object[] { "Data1: value", "Data2: hello world", "Data3: hello hello"});
        }
        void listBox1_DrawItem(object sender, DrawItemEventArgs e) {
            var box = (ListBox)sender;
            e.DrawBackground();
            if (e.Index < 0) return;
            string[] temp = box.Items[e.Index].ToString().Split(':');
            int size = (int)(TextRenderer.MeasureText(e.Graphics, temp[0], box.Font).Width + 0.5);
            var rc = new Rectangle(e.Bounds.Left, e.Bounds.Top, (int)size, e.Bounds.Height);
            var fmt = TextFormatFlags.Left;
            TextRenderer.DrawText(e.Graphics, temp[0] + ":", box.Font, rc, e.ForeColor, fmt);
            if (temp.Length > 1) {
                using (var bold = new Font(box.Font, FontStyle.Bold)) {
                    rc = new Rectangle(e.Bounds.Left + size, e.Bounds.Top, e.Bounds.Width - size, e.Bounds.Height);
                    TextRenderer.DrawText(e.Graphics, temp[1], bold, rc, e.ForeColor, fmt);
                }
            }
            e.DrawFocusRectangle();
        }
    }
