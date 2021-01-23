            bool focus = false;
            private void Form1_Paint(object sender, PaintEventArgs e)
            {
                if (focus)
                {
                    textBox1.BorderStyle = BorderStyle.None;
                    Pen p = new Pen(Color.Red);
                    Graphics g = e.Graphics;
                    int variance = 3;
                    g.DrawRectangle(p, new Rectangle(textBox1.Location.X - variance, textBox1.Location.Y - variance, textBox1.Width + variance, textBox1.Height +variance ));
                }
                else
                {
                    textBox1.BorderStyle = BorderStyle.FixedSingle;
                }
            }
    
            private void textBox1_Enter(object sender, EventArgs e)
            {
                focus = true;
                this.Refresh();
            }
    
            private void textBox1_Leave(object sender, EventArgs e)
            {
                focus = false;
                this.Refresh();
            }
