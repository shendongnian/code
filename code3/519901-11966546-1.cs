    PictureBox[,] pics = new PictureBox[10,10];
            int size = 20;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    pics[i, j] = new PictureBox();
                    pics[i, j].Size = new System.Drawing.Size(size, size);
                    pics[i, j].Location = new Point(size * 2 * i + 10, size * 2 * j + 10);
                    //pics[i,j].Image = image
                    pics[i, j].BackColor = Color.AliceBlue;
                    pics[i, j].Parent = this;
                }
            }
