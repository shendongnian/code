    private void button1_Click(object sender, EventArgs e) {
       if (listBox1.Items.Contains(listBox1.SelectedItem)) {
            MessageBox.Show("Can't add the same type twice");
       }
       else {
            listBox1.Items.Add(listBox1.SelectedItem);
                }
            }
