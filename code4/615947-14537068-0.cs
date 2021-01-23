        private System.Windows.Forms.Timer TextUpdateTimer = new System.Windows.Forms.Timer();
        private string MyString = "This is a test string to stylize your RichTextBox1";
        private int TextUpdateCount = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            //Sets duration between firing the "Timer.Tick Event"
            TextUpdateTimer.Interval = 100;
            TextUpdateTimer.Tick += new EventHandler(TextUpdateTimer_Tick);
            TextUpdateCount = 0;
            TextUpdateTimer.Start();
        }
        private void TextUpdateTimer_Tick(object sender, EventArgs e)
        {
            if(TextUpdateCount == MyString.Length) {
                TextUpdateTimer.Stop();
                return;
            }
            richTextBox1.AppendText(MyString[TextUpdateCount].ToString());
            TextUpdateCount++;
        }
