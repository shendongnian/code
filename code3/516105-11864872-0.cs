                pictureBox1 = new PictureBox();
                pictureBox1.Image = Resource.myImage;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                //2 is used just for try to fit image into "white" area of ComboBox
                pictureBox1.ClientSize = new Size(comboBox1.Size.Height - 2, comboBox1.Size.Height - 2);
                pictureBox1.BackColor = System.Drawing.Color.Transparent;
                pictureBox1.Left = 1;
                pictureBox1.Top = 1;
                pictureBox1.Parent = this.comboBox1;
                pictureBox1.Enabled = true;
                pictureBox1.Visible = true;
