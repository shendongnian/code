        private void button1_Click(object sender, EventArgs e) {
            listBox1.BeginUpdate();
            for (long i = 0; i < 66000; i++) {
                listBox1.Items.Add(i.ToString());
            }
            listBox1.EndUpdate();
            listBox1.SelectedIndex = listBox1.Items.Count - 1;
        }
