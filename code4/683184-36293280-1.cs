    public partial class Form_Begin : Form
    {
        PictureBox[] pictureBoxs = new PictureBox[6];
        public Form_Begin()
        {
            InitializeComponent();
            pictureBoxs[0] = pictureBox1; pictureBoxs[1] = pictureBox2; pictureBoxs[2] = pictureBox3;
            pictureBoxs[3] = pictureBox4; pictureBoxs[4] = pictureBox5;   pictureBoxs[5] = pictureBox6;     
        }
