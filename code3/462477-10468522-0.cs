      private void Form1_Load(object sender, EventArgs e)
            {
                //in form load the radio is checked or unckecked
                //here my radio is unchecked at load
                pictureBox1.Image = WindowsFormsApplication5.Properties.Resources.Add;
                pictureBox1.Tag = "UnChecked";
            }
       private void pictureBox1_Click(object sender, EventArgs e)
            {
                //after pictiurebox clicked change the image and tag too
                if (pictureBox1.Tag.ToString() == "Checked")
                {
                    pictureBox1.Image = WinFormsApplication.Properties.Resources.Add;
                    pictureBox1.Tag = "UnChecked";
                }
                else
                {
                    pictureBox1.Image = WinFormsApplication.Properties.Resources.Delete;
                    pictureBox1.Tag = "Checked";
                }
            }
