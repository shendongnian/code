    int _HoverIndex = -1;
    private void listBox1_MouseMove(object sender, MouseEventArgs e) {
      int index = listBox1.IndexFromPoint(e.Location);
      if (index != _HoverIndex) {       
        _HoverIndex = index;
        if (_HoverIndex == -1)
          textBox1.Text = string.Empty;
        else
          textBox1.Text = listBox1.Items[_HoverIndex].ToString();
      }
    }
    private void listBox1_MouseLeave(object sender, EventArgs e) {
      _HoverIndex = -1;
      textBox1.Text = string.Empty;
    }
