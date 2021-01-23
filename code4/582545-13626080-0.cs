                Image img = Image.FromFile("media\\a.png"); // a.png has 312X312 width and height
                int widthThird = (int)((double)img.Width / 3.0 + 0.5);
                int heightThird = (int)((double)img.Height / 3.0 + 0.5);
                Bitmap[,] bmps = new Bitmap[3,3];
                for (int i = 0; i < 3; i++)
                    for (int j = 0; j < 3; j++)
                    {
                        bmps[i, j] = new Bitmap(widthThird, heightThird);
                        Graphics g = Graphics.FromImage(bmps[i, j]);
                        g.DrawImage(img, new Rectangle(0, 0, widthThird, heightThird), new Rectangle(j * widthThird, i * heightThird, widthThird, heightThird), GraphicsUnit.Pixel);
                        g.Dispose();
                    }
                pictureBox1.Image = bmps[0, 0];
                pictureBox2.Image = bmps[0, 1];
                pictureBox3.Image = bmps[0, 2];
                pictureBox4.Image = bmps[1, 0];
                pictureBox5.Image = bmps[1, 1];
                pictureBox6.Image = bmps[1, 2];
                pictureBox7.Image = bmps[2, 0];
                pictureBox8.Image = bmps[2, 1];
                pictureBox9.Image = bmps[2, 2];
