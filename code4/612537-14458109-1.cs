    using (StreamWriter writter = File.AppendText(path)) 
    {
       writter.WriteLine("This");
       writter.WriteLine("is Extra");
       writter.WriteLine("Text");
    }
