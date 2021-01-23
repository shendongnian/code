    private void button1_Click(object sender, EventArgs e) {
      int i = listBox1.SelectedIndex;
      if(i > -1) {
         listBox1.Items.RemoveAt(i);
         if(listBox1.Items.Count > 0)
           listBox1.SelectedIndex = i < listBox1.Items.Count ? i : listBox1.Items.Count - 1;
      }
    }
