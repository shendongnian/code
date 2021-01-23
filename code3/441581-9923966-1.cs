        private void UpdateText(string text)
        {
           textBox1.SuspendLayout();
           textBox1.Text = textBox1.Text + text + System.Environment.NewLine;
           textBox1.SelectionStart = textBox1.Text.Length;
           textBox1.ScrollToCaret();
           textBox1.ResumeLayout();
         }
