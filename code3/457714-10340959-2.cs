    public IEnumerable<string> GenerateTextOutput()
    {
       //...
       //using SqlDataReader instead
       while(reader.Read())
       {
         //assemble string for next row
         string txt = "...";
         yield return txt;
       }
    }
