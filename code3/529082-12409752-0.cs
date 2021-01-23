    private void button1_Click(object sender, EventArgs e)
    {
        listBox1.SelectedIndex = 0;
        while (listBox1.Items.Count != 1)
            {
                 geckoWebBrowser1.DocumentCompleted += new EventHandler(browser_DocumentCompleted);
                 geckoWebBrowser1.Navigate(textBox1.Text);
            }
    }
    void browser_DocumentCompleted(object sender, EventArgs e)
    {
        // Do stuff here      
    }
