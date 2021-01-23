    string str;
    // if you're not reading from a file, String.Split('\n'), can help you
    using (StreamReader sr = new StreamReader("doc.txt"))
    {
        while ((str = sr.ReadLine()) != null)
        {
            if (str.Trim() == "Note:") // you may also use a regex here if applicable
            {
                str = sr.ReadLine();
                break;
            }
        }
    }
    Console.WriteLine(str);
