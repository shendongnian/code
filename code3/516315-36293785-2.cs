    public partial class Form_Begin : Form
        {
            PictureBox[] pictureBoxs = new PictureBox[50];
            public Form_Begin()
            {
                InitializeComponent();
                pictureBoxs[0] = pictureBox1;
                pictureBoxs[1] = pictureBox2;
                pictureBoxs[2] = pictureBox3;
                pictureBoxs[3] = pictureBox4;}
    
    
    
                List<PictureBox> pictureBoxes = new List<PictureBox>();
     private void buttonX1_Click(object sender, EventArgs e)
                {
                    for (int i = 0; i <2; i++)
                    {
                        pictureBoxs[i].Image =your_name_project.Properties.Resources.Image_1;                     // Load Image_1 from Resources on property of picturebox  
                    }
                    for (int i = 2; i < 4; i++)
                    {
                        pictureBoxs[i].Image =your_name_project.Properties.Resources.Image_2;                    // Load Image_12 from Resources on property of picturebox 
    
                    }
