    List<string> str = new List<String>();
    str.Add("A");
    str.Add("B");
    str.Add("C");
    str.Add("D");
    str.Add("E");
    using (StreamWriter writer = new StreamWriter("PathOfFile"))
    {
         foreach(string s in str)
         {
              // writer.Write(s); // Writes in same line
              writer.WriteLine(s);// Writes in next line
         }
    }
