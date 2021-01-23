    public partial class Form_Begin : Form
    {
        PictureBox[] pictureBoxs = new PictureBox[6];
        public Form_Begin()
        {
            InitializeComponent();
            pictureBoxs[0] = pictureBox1;
            pictureBoxs[1] = pictureBox2;
            pictureBoxs[2] = pictureBox3;
            pictureBoxs[3] = pictureBox4;
            pictureBoxs[4] = pictureBox5;
            pictureBoxs[5] = pictureBox6;
              
        }
        List<PictureBox> pictureBoxes = new List<PictureBox>();
   
   
            private void buttonX1_Click(object sender, EventArgs e)
            {
                for (int i = 0; i <3; i++)
                {
                    // Load Image from Resources
                    pictureBoxs[i].Image =your_name_project.Properties.Resources.image_1;//if this instruction is not correct inter your names image in property of picturebox in image    
                 
                }
                for (int i = 3; i < 6; i++)
                {
                    // Load Image from Resources
                    pictureBoxs[i].Image = your_name_project.Properties.Resources.Image_2;
                }
            } 
        }
}
