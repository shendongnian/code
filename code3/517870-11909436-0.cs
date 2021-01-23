    public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                label1.Paint += new PaintEventHandler(label1_Paint);
            }
    
            void label1_Paint(object sender, PaintEventArgs e)
            {
                SizeF size = e.Graphics.MeasureString(label1.Text, label1.Font);
                this.label1.Width = (int)size.Width;
                this.label1.Height = (int)size.Height;
            }
        }
