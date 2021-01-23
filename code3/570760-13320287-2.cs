        private void button1_Click(object sender, EventArgs e)
        {
            string sent = chatBox.Text;
            displayBox.AppendText(sent);
            displayBox.AppendText(Environment.NewLine);
            // OR you can use string.operator + together with Text property
            displayBox.Text += sent;
            displayBox.Text += Environment.NewLine;
        }
