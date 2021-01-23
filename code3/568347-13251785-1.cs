    RichTextBox _RichTextBox = new RichTextBox();
    try
    {
         _RichTextBox.LoadFile(@"D:\Resources\text.txt", RichTextBoxStreamType.RichText);
    }
    catch (Exception EX)
    {
         if (EX.Message.ToLower().Contains("format is not valid"))
         {
              _RichTextBox.LoadFile(@"D:\Resources\text.txt", RichTextBoxStreamType.PlainText);
         }
    }
