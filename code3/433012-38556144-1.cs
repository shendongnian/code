    private void button1_Click(object sender, EventArgs e)
    {
        // find some text
        var index = this.richTextBox1.Find(this.textBox1.Text);
        if (index>-1)
        {
            using (var gr = Graphics.FromImage(pictureBox1.Image))
            {
                // calculate where to postion the bar
                var textpos = index / (double)this.richTextBox1.Text.Length;
                var position = (double) pictureBox1.Height * textpos;
                Trace.WriteLine(String.Format("{0}:{1}:{2}", index, textpos, position));
    
                // draw it
                gr.DrawLine(new Pen(Color.Red, 4), 0, (int)position, pictureBox1.Width, (int)position);
                pictureBox1.Invalidate();
            }
        }
    }
