    private void richTextBox1_MouseDown(object sender, MouseEventArgs e)
    {
        // Continue if the Right mouse button was clicked
        if (e.Button == MouseButtons.Right)
        {
            // Check if the selected item starts with http://
            if (richTextBox1.SelectedText.IndexOf("http://") > -1)
            {
                // Avoid popping the menu if the value contains spaces
                if (richTextBox1.SelectedText.Contains(' '))
                {
                   // Show the menu
                   contextMenuStrip1.Show(Cursor.Position.X, Cursor.Position.Y);
                }
            }   
        }
    }
