    byte[] b = new byte[55000];
    StringBuilder myStringBuilder = new StringBuilder();
    
    for(int i = 0; i < b.Length; i++)
    {
        myStringBuilder.AppendLine(ConvertToString(b[i]));
    }
    Console.Write(myStringBuilder.ToString());
