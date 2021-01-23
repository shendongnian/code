    // When spaces are not allowed
    if (string.IsNullOrWhiteSpace(txtBox1.Text) || string.IsNullOrWhiteSpace(txtBox2.Text))
      //...give error...
    
    // When spaces are allowed
    if (string.IsNullOrEmpty(txtBox1.Text) || string.IsNullOrEmpty(txtBox2.Text))
      //...give error...
