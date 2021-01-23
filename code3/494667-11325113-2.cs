        Bitmap bt;
        private void Form_Load(object sender, EventArgs e)
        {
            bt = new Bitmap(100,100);
            pictureBox1.Image = bt;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g = Graphics.FromImage(bt);
            int i = 9;
            int k;
            String[] letter1 = new String[9] { "b", "W", "b", "w", "B", "w", "B", "w", "B" };
            
            Pen b = new Pen(Color.Black, 1.0f);
            Pen B = new Pen(Color.Black, 2.0f);
            Pen w = new Pen(Color.White, 1.0f);
            Pen W = new Pen(Color.White, 2.0f);
            for (int j = 0; j <= 8; j++)
            {
                String array = letter1[j];
                if (array.Equals("b") || array.Equals("w"))
                {
                    i = i + 1;
                    k = 50;
                    if (array.Equals("b"))
                    {
                        g.DrawLine(b, i, 10, i, k);
                    }
                }
                else
                    if (array.Equals("B") || array.Equals("W"))
                    {
                        i = i + 2;
                        k = 51;
                        if (array.Equals("B"))
                            g.DrawLine(B, i, 10, i, k);
                    }
            }
            pictureBox1.Refresh();
            pictureBox1.Image.Save("c:\\test.bmp");
            
        }
