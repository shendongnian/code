    public void LoadFileFromExplorer()
    {
       string[] args = Environment.GetCommandLineArgs();
       if (args.Length > 1)
       {
         string filename1 = Environment.GetCommandLineArgs()[1];
         richTextBox1.LoadFile(filename1, RichTextBoxStreamType.PlainText);
       }
    }
