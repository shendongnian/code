    string[] parts = null;
    richTextBox8.Invoke((Action)(() => 
        {
            parts = richTextBox8.Text.Split(new string[] { " " },
            StringSplitOptions.RemoveEmptyEntries); //added semicolon
        }));
