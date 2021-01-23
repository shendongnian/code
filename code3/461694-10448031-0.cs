    private void button1_Click(object sender, EventArgs e)
            {
                end = int.Parse( textBox2.Text);
                timer1.Start();
    
            }
            private int end = 0;
            private int start = 0;
            private void timer1_Tick(object sender, EventArgs e)
            {
                if (start == end)
                {
                    timer1.Stop();
                }
                else
                {
                    start++;
                    textBox1.Text = start.ToString();
                }
            }
