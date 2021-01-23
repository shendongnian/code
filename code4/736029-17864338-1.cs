      public long  Replace(String text1, String text2)
     {
      long replaceCount = 0;
       currentFileStream = File.Open(CurrentFileName, FileMode.Open, FileAccess.ReadWrite, FileShare.None);
    StringBuilder sb = new StringBuilder();
    using (BufferedStream bs = new BufferedStream(currentFileStream))
    using (StreamReader sr = new StreamReader(bs))  
    {
        string line;
        while ((line = sr.ReadLine()) != null)
        {
            string textToAdd = line;
            if (line.Contains(text1))
            {
                textToAdd = line.Replace(text1, text2);
                // Here I should save changed line
                replaceCount++;
            }
            sb.Append(textToAdd);
        }
    }
    using (FileStream fileStream = new FileStream(filename , fileMode, fileAccess))
            {
                StreamWriter streamWriter = new StreamWriter(fileStream);
                streamWriter.Write(sb.ToString());
                streamWriter.Close();
                fileStream.Close();
            }
    return replaceCount;
}
