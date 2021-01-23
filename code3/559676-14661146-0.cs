        public void WriteTextFile(String FileName)
        {
        TextWriter objTextWriter= new StreamWriter(FileName);
        objTextWriter.WriteLine(DateTime.Now); //Writing current time in textfile
        objTextWriter.Close();
        }
        public String ReadTextFile(String FileName)
        {
        Textreader objTextReader= new StreamReader(FileName);
        String fileContent = objTextWriter.ReadLine();
        objTextReader.Close();
        return fileContent;
        }
