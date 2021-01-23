    if (openFile1.ShowDialog() == System.Windows.Forms.DialogResult.OK )
        {             
    
        TextRange range;
        
        System.IO.FileStream fStream;
        
        if (System.IO.File.Exists(openFile1.FileName))
        
            {
        
                range = new TextRange(RichTextBox1.Document.ContentStart, RichTextBox1.Document.ContentEnd);
        
                fStream = new System.IO.FileStream(openFile1.FileName, System.IO.FileMode.OpenOrCreate);
        
                range.Load(fStream, System.Windows.DataFormats.Rtf );
        
                fStream.Close();
        
            }
    
    }
