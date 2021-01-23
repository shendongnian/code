    sb.AppendLine(message);
    if (i % 1000 == 0)
    {
        Console.WriteLine(i + " " + DateTime.Now.ToLongTimeString());
        File.AppendAllText(@"e:\temp\query2.sql", textToWrite.ToString());
        textToWrite = new StringBuilder();
    }
