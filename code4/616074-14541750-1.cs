    button1.Click += NumericButtonClick;
    ...
    button9.Click +=NumericButtonClick;
    
    
    private void NumericButtonClick(object sender, EventArgs e) {
            CheckIfEqual();
            textBox1.Text = textBox1.Text + ((Button)sender).Text;
    }
