    private void button1_Click(object sender, EventArgs e)
            {
                pictureBox1.Width = (int)(Width * 0.80);
                pictureBox1.Height = (int)(Height * 0.80);
    
    
                // open file dialog 
                OpenFileDialog open = new OpenFileDialog();
                
                // image filters
                open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    // display image in picture box
                    pictureBox1.Image = new Bitmap(open.FileName);
                    // image file path
                    //  textBox1.Text = open.FileName;
                    Graphics g = Graphics.FromImage(pictureBox1.Image);
                    g.FillRectangle(Brushes.Red, 0, 0, 20, 50);
                    pictureBox1.Refresh();
                }
            }
