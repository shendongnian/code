    public void insertRowsToDb(string multiTextString)
    {
        int i = 0;
        string insertString = "";
        string[] result = multiTextString.Split(new string[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
        foreach (string s in result)
        {
            for (i = 0; i = 2; i++)
            {
                insertString = insertString + s+",";
                //Console.WriteLine(s);
            }
            insertString = insertString.Substring(0, insertString .Length - 1);//Trim last comma
            insertToDb(insertString);//Your DB insert procedure here
            i = 0;
        }
    }
