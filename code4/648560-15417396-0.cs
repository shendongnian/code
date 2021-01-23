    using (TextWriter tw = new TextWrite("D:\\output.txt"))
    {
        using (StreamReader reader = new StreamReader("D:\\input1.txt"))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split(' ');
                string[] stopWord = new string[] { "is", "are", "am","could","will" };
                foreach (string word in stopWord)
                {
                    line = line.Replace(word, "");
                    tw.Write("+"+line);
                }
            }
        }
    }
