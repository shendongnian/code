    PictureBox[] pics = new PictureBox[10];
            int size = 20;
            for (int i = 0; i < 10; i++)
            {
                pics[i] = new PictureBox();
                pics[i].Size = new System.Drawing.Size(size, size);
                pics[i].Location = new Point(size * 2 * i + 10, size);
                //pics[i].Image = image
                pics[i].BackColor = Color.AliceBlue;
                pics[i].Parent = this;
            }
