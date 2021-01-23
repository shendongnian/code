    System.Windows.Forms.RichTextBox rtBox = new System.Windows.Forms.RichTextBox();
    
    string richText = text// The rich text (with bullets and so on.)
    rtBox.Rtf = richText ;
    string plainText = rtBox.Text;
    
    System.IO.File.WriteAllText(@"output.txt", plainText);
