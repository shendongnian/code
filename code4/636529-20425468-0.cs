     using System.Drawing;
    
     private void rbtPruef_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtDePruef.Checked)
            {
                pictureBox2.Location = new Point(112, 80);
                pictureBox1.Location = new Point(242, 80);
            }
            else
            {
                pictureBox2.Location = new Point(242, 80);
                pictureBox1.Location = new Point(112, 80);
            }
        }
