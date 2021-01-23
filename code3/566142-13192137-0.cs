            int selectionStart;
    
            private void button1_Click(object sender, EventArgs e)
            {
                Graphics g = textBox1.CreateGraphics();
                SizeF size = g.MeasureString("A", textBox1.Font);
                g.Dispose();
                int index = textBox1.GetCharIndexFromPosition(new Point(0, (int)(2 * size.Height + 0.5)));
                selectionStart = index;
            }
    
            private void button3_Click(object sender, EventArgs e)
            {
                textBox1.SelectionStart = selectionStart;
                textBox1.ScrollToCaret();
            }
