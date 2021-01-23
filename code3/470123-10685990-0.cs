    private void ShowRichMessageBox(string title, string message)
            {
                RichTextBox rtbMessage = new RichTextBox();
    
                rtbMessage.Text = message;          
    
                Form RichMessageBox = new Form();
                RichMessageBox.Text = title;
                RichMessageBox.MaximizeBox = false;
                RichMessageBox.MinimizeBox = false; 
    
                RichMessageBox.Controls.Add(rtbMessage);
                RichMessageBox.ShowDialog();
            }
