        public partial class Form1 : Form
        {
            Bitmap b = new Bitmap(320, 200);
            public Form1()
            {
                InitializeComponent();
                CenterTheBox();
            }
    
            private void Form1_Resize(object sender, EventArgs e)
            {
                CenterTheBox();
            }
    
            void CenterTheBox()
            {
                pictureBox1.Size = b.Size;
                var left = (tabPage1.ClientRectangle.Width - pictureBox1.ClientRectangle.Width) / 2;
                var top = (tabPage1.ClientRectangle.Height - pictureBox1.ClientRectangle.Height) / 2;
                pictureBox1.Location = new Point(tabPage1.ClientRectangle.Location.X + left, tabPage1.ClientRectangle.Location.Y + top);
                
            }
        }
