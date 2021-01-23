        int ImageNum = 1;
        
        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            if (ImageNum == 1)
            {
                button1.Image = Image2;
                ImageNum = 2;
            }
            else
            {
                button1.Image = Image1;
                ImageNum = 1;
            }
        }
