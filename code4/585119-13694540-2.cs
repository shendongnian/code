    string s = "safsadfd\r\ndfgfdg\r\n\r\ndfgfgg";
    string[] lines = s.Split('\n');
    int i;
    for (i = 0; i < lines.Length; i++)
    {
        if (string.IsNullOrWhiteSpace(lines[i]))     
        //if (lines[i].Length == 0)          //or maybe this suits better..
        //if (lines[i].Equals(string.Empty)) //or this
        {
            Console.WriteLine(i);
            break;
        }
    }
    Console.WriteLine(string.Join("\n",lines.Take(i)));
