    private void button1_Click(object sender, EventArgs e)
    {
        //test call of the rtBox
        ShowRichMessageBox("Test", File.ReadAllText("test.txt"));
    }
    
    /// <summary>
    /// Shows a Rich Text Message Box
    /// </summary>
    /// <param name="title">Title of the box</param>
    /// <param name="message">Message of the box</param>
    private void ShowRichMessageBox(string title, string message)
    {
        RichTextBox rtbMessage = new RichTextBox();
        rtbMessage.Text = message;
        rtbMessage.Dock = DockStyle.Fill;
        rtbMessage.ReadOnly = true;
        rtbMessage.BorderStyle = BorderStyle.None;
    
        Form RichMessageBox = new Form();
        RichMessageBox.Text = title;
        RichMessageBox.StartPosition = FormStartPosition.CenterScreen;
    
        RichMessageBox.Controls.Add(rtbMessage);
        RichMessageBox.ShowDialog();
    }
