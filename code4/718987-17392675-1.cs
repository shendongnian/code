        private void addMessage(string from, string message)
        {
            listBox1.Items.Add(DateTime.Now.ToString("[HH:mm:ss]"));
            listBox2.Items.Add(from);
            listBox3.Items.Add(message);
        }
