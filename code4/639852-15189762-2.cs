    using (TextWriter tw = File.CreateText(@"c:\temp\result.txt"))
    using (StreamReader reader = new StreamReader(@"stackov1.txt"))
    {
        string line;
        String lines = "";
        while ((line = reader.ReadLine()) != null)
        {
            String[] str = line.Split('\t');
            String[] words = str[3].Split(' ');
            for (int k = 0; k < words.Length; k++)
            {
                lines = lines + str[0] + "\t" + str[1] + "\t" + str[2] + "\t" + words[k] + "\r\n";
            }
        }
        tw.Write(lines);
    }
