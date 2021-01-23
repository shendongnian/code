    using (var reader = new StringReader(myString))
    {
        do
        {
            StringBuilder newString = null;
            StringWriter newStringWriter = null;
            if (lineCounter % 20 == 0)
            {
                 newString = new StringBuilder();
                 newStringWriter = new StringWriter(newString);
                 newStringCollection.Add(newString);
            } 
            string line = reader.ReadLine();
            if (!string.isNullOrEmpty(line))
            {
                 newStringWriter.WriteLine(line);
                 lineCounter++;
            }
        }
        while (line != null)
    }
