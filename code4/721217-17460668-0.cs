     if (checkBox1.Checked == false)
     {
         pictureBox1.Image = Properties.Resources.On;
         pictureBox1.Tag = "ON";
         checkBox1.Checked = true;            
     }
     else
     {
         pictureBox1.Image = Properties.Resources.Off;
         pictureBox1.Tag = "OFF";
         checkBox1.Checked = false;
     }
