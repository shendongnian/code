    private void RichTextBox_Drop(object sender, DragEventArgs e)
    {
        if (e.Data.GetDataPresent(DataFormats.FileDrop))
        {
            string[] docPath = (string[])e.Data.GetData(DataFormats.FileDrop);
    
            // By default, open as Rich Text (RTF).
            var dataFormat = DataFormats.Rtf;
    
            // If the Shift key is pressed, open as plain text.
            if (e.KeyStates == DragDropKeyStates.ShiftKey)
            {
                dataFormat = DataFormats.Text;
            }
    
            System.Windows.Documents.TextRange range;
            System.IO.FileStream fStream;
            if (System.IO.File.Exists(docPath[0]))
            {
                try
                {
                    // Open the document in the RichTextBox.
                    range = new System.Windows.Documents.TextRange(richTextBox1.Document.ContentStart, richTextBox1.Document.ContentEnd);
                    fStream = new System.IO.FileStream(docPath[0], System.IO.FileMode.OpenOrCreate);
                    range.Load(fStream, dataFormat);
                    fStream.Close();
                }
                catch (System.Exception)
                {
                    MessageBox.Show("File could not be opened. Make sure the file is a text file.");
                }
            }
        }
