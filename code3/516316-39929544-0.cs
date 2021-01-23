     private void picbutton_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            PictureBox[] picture = new PictureBox[5];
            int x = 0;
            int y = 15;
            for (int index = length; index < picture.Length; index++)
            {
                    picture[index] = new PictureBox();
                    picture[index].Size = new Size(100, 50);
                    open.Title = "OPen Image";
                    open.Filter = "JPG Files (*.jpg)|*.jpg|JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|GIF Files (*.gif)|*.gif";
                    DialogResult result = open.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        picture[index].BackgroundImage = new Bitmap(open.FileName);
                        picture[index].SizeMode = PictureBoxSizeMode.AutoSize;
                        listBox1.Controls.Add(picture[index]);
                        if ((x % 3 == 0) && (index != 0))
                        {
                            y = y + 150; // 3 images per rows, first image will be at (20,150)
                            x = 0;
                        }
                        picture[index].Location = new Point(x * 210 + 20, y);
                        picture[index].Size = new Size(200, 150);
                        x++;
                }
            }
        }
