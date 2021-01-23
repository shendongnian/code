    public void log(string msg)
    {
      StreamWriter file2 = new StreamWriter(@"c:\file.txt", true);
      file2.WriteLine(msg);
      file2.Close();
    }
