    // Form1's button5 clicked event handler.
    private void OnButton5Clicked(object sender, EventArgs e)
    {
        form2.button1.click += this.OnSearchButtonClicked;
    }
    // form2.button1 clicked event handler.
    // this method will rise when form2.button1 clicked.
    private void OnSearchButtonClicked(object sender, EventArgs e)
    {
        if (form2.textBox1.Text == "")
            {
                MessageBox.Show("Please enter keyword to search");
            }
            else 
            {
                // unsign from event!!!
                form2.button1.click -= this.OnSearchButtonClicked;
                // here you can use form2.textBox1.text
                string searchRequest = form2.textBox1.Text;
            }
    
        // your business-logic...
    }
