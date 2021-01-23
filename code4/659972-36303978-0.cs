    namespace your_name_project
    {
        public partial class Form_Begin : Form
        {
            PictureBox[] pictureBoxs = new PictureBox[6];
            public Form_Begin()
            {
                InitializeComponent();
                pictureBoxs[0] = pictureBox1; pictureBoxs[1] = pictureBox2; pictureBoxs[2] = pictureBox3;
                pictureBoxs[3] = pictureBox4; pictureBoxs[4] = pictureBox5;   pictureBoxs[5] = pictureBox6;     
            }
    //continue 
            List<PictureBox> pictureBoxes = new List<PictureBox>();
       
                private void buttonX1_Click(object sender, EventArgs e)
                {
                    for (int i = 0; i <3; i++)
                    {
                        pictureBoxs[i].Image =your_name_project.Properties.Resources.image_1;// load image1 and Image_2from resource in property of picturebox  
                    }
                    for (int i = 3; i < 6; i++)
                    {
                        pictureBoxs[i].Image = your_name_project.Properties.Resources.Image_2;
                    }
                } 
            }
    }
