        private void button1_Click(object sender, EventArgs e)
        {
            string sent = chatBox.Text;
            displayBox.AppendText(sent);
            displayBox.AppendText(Environment.NewLine);
        }
