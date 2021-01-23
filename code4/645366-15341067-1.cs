    StreamReader reader = new StreamReader(@"C:\test.txt");
    StreamWriter writer = new StreamWriter(@"C:\test2.txt", true);
    List<string> result = new List<string>();
    string new_line = reader.ReadLine();
    string full_line = null;
    while (new_line != null)
    {
        full_line = (full_line == null) ? new_line : full_line + new_line;
        if (new_line.EndsWith("\"") && !new_line.EndsWith("\\\""))
        {
            //Write to the List
            result.Add(full_line);
            //Reset the whole line
            full_line = null;
        }
        
        //Read the next line
        new_line = reader.ReadLine();
    }
    //Close the connection
    reader.Close();
    foreach (string readResult in result)
        writer.WriteLine(readResult);
