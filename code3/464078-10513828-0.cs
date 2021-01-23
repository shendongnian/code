    StringBuilder strBuilder= new StringBuilder();
    foreach (string path in filePaths)
    {
         StreamReader singfile = new StreamReader(path);
         string  file_text = singfile.ReadToEnd();
         strBuilder.AppendLine(file_text);
         fs.Close();
    }
    Console.WriteLine(strBuilder.ToString());
