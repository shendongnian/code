    using (StreamWriter writer = File.AppendText(path)) 
    {
       writer.WriteLine("This");
       writer.WriteLine("is Extra");
       writer.WriteLine("Text");
    }
