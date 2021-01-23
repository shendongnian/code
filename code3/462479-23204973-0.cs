     public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            Bitmap bm1;
            Bitmap bm2;
            private void button1_Click(object sender, EventArgs e)
            {
                bm1 = new Bitmap(Properties.Resources.firegirl1);
                bm2 = new Bitmap(Properties.Resources.Zemli2);
                pictureBox1.Image = bm1;
                pictureBox2.Image = bm2;
                if (pictureBox1.Image==pictureBox2.Image)
                {
                    MessageBox.Show("Some");
                }
                else
                {
                    MessageBox.Show("Differ");
                }
            }
    }
