    public partial class Form1 : Form
    {
        Image img1 = Image.FromFile("Peg_Red.png");
        Image img2 = Image.FromFile("Peg_Blue.png");
        Image img3 = Image.FromFile("Peg_Green.png");
        Image img4 = Image.FromFile("Peg_Orange.png");
        public Form1()
        {
            InitializeComponent();
            img1.Tag = 1;
            img2.Tag = 2;
            img3.Tag = 3;
            img4.Tag = 4;
            label1.Image = img1;
            label2.Image = img2;
            label3.Image = img3;
            label4.Image = img4;
        }
        private void DD_MouseDown(object sender, MouseEventArgs e)
        {
            Label lblPic = (Label)sender;
            lblPic.DoDragDrop(lblPic.Image, DragDropEffects.Copy);
        }
        private void DD_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Bitmap)))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }
        private void DD_DragDrop(object sender, DragEventArgs e)
        {
            Label lblPic = (Label)sender;
            Graphics g = lblPic.CreateGraphics();
            var image = (Image)e.Data.GetData(typeof(Bitmap));
            var index = (int)image.Tag;
            g.DrawImage(image, new Point(0, 0));
            switch (index)
            {
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                default:
                    break;
            }
            g.Dispose();
            image.Dispose();
        } 
    }
