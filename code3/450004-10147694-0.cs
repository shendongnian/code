    protected void ReplaceFile(string FilePath, string NewFilePath)
    {
       using (StreamReader vReader = new StreamReader(FilePath))
       {
          using (StreamWriter vWriter = new StreamWriter(NewFilePath))
          {
             int vLineNumber = 0;
             while (!vReader.EndOfStream)
             {
                string vLine = vReader.ReadLine();
                vWriter.WriteLine(ReplaceLine(vLine, vLineNumber++));
             }
          }
       }
    }
    protected string ReplaceLine(string Line, int LineNumber )
    {
       //Do your string replacement and 
       //return either the original string or the modified one
       return Line;
    }
