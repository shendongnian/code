    public class Form1 : Form
    {
        private Dictionary<string, PictureBox> pictureBoxes;
        
        public Form1()
        {
            pictureBoxes = new Dictionary<string, PictureBox>()
            {
                  {"Pictures\\green.png", pictureBox_D},
                  {"Pictures\\blue.png", pictureBox_B},
                  // Etcetera
            }
        }
    }
