    private void richTextBox1_KeyUp(object sender, KeyEventArgs e)
            {
                if (e.Key != System.Windows.Input.Key.Enter) return;
    
                var textRange = new TextRange(richTextBox1.Document.ContentStart, richTextBox1.Document.ContentEnd);
                string rtf;
                using (var memoryStream = new MemoryStream())
                {
                    textRange.Save(memoryStream, DataFormats.Rtf);
                    rtf = ASCIIEncoding.Default.GetString(memoryStream.ToArray());
                }
    
               
    
                MemoryStream stream = new MemoryStream(ASCIIEncoding.Default.GetBytes(rtf));
                richTextBox2.SelectAll();
                richTextBox2.Selection.Load(stream, DataFormats.Rtf);
            }
