    System.IO.StreamReader streamReader = new System.IO.StreamReader("input", true);
    System.IO.StreamWriter streamWriter = new System.IO.StreamWriter("output", false);
    streamWriter.Write(streamReader.ReadToEnd());
    streamWriter.Close();
    streamReader.Close();
