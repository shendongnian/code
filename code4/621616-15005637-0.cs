    private void textBox1_MouseDoubleClick(object sender, MouseEventArgs e)
    {
        this.Focus();
        System.Threading.Thread.Sleep(500);
        OpenOutlookMail(textBox1.Text);
    }
