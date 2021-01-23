    private void SetTextButton_Click(object sender, EventArgs e)
    {
        Thread t = new Thread(new ThreadStart(AssignLongText));
        t.Start();
    }
    private void AssignLongText()
    {
        richTextBox1.Text = s;
    }
