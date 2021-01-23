    System.Text;
    System.IO;
System.Text is for the StringBuilder class to append all the lines from the file.
System.IO is for FileStream and StreamReader class to access your file. Both classes implement the IDisposable interface, so you can use the using statements to close your streams. (example below)
There are many ways to get content from your file, I personally prefer to use a while(condition) loop to iterate over the contents. In the condition clause, use !lReader.EndOfStream. While <b>not</b> end of stream, continue iterating over the file.
    public string[] GetCsvContent(string iFileName)
    {
        string[] oCsvContent = null;
        using (FileStream lFileStream = 
                      new FileStream(iFilename, FileMode.Open, FileAccess.Read))
        {
            StringBuilder lFileContent = new StringBuilder();
            using (StreamReader lReader = new StreamReader(lFileStream))
            {
                while (!lReader.EndOfStream)
                {
                    lFileContent.Append(lReader.ReadLine());
                }
            }
            oCsvContent = lFileContent.ToString().Split(',');
        }
        return oCsvContent;
    }
