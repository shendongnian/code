    public partial class Form1 : Form
    {
        bool[] selected = new bool[24];
        public Form1()
        {
            InitializeComponent();
            foreach (PictureBox  pb in panel1.Controls)
            {
                pb.Click += new EventHandler(pictureBox_Click);
            }
        }
        private void pictureBox_Click(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            int index ;
            if (int.TryParse(pb.Tag.ToString(), out index))
            {
                if (selected[index])
                {
                    selected[index] = false;
                    pb.BackColor = Color.White;
                }
                else
                {
                    selected[index] = true;
                    pb.BackColor = Color.Red;
                }
            }
        }
    }
