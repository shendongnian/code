    private void button1_Click(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync(richTextBox1.Text);
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            string text = (string)e.Argument;
            MessageBox.Show(text);
        }
