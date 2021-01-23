    int occur_yes = 0;
    int occur_no  = 0;
    // open file
    using (StreamReader r = new StreamReader("inputFile.txt"))
    {
        // read lines one at a time
        string line;
        while ((line = r.ReadLine()) != null)
        {
            // split the line
            string[] cols = line.Split('\t');
            if (cols[0] == "sunny")
            {
                // check last column only if the first one is "sunny"
                if (cols[4] == "N")
                    occur_no++;
                else if (cols[4] == "P")
                    occur_yes++;
            }
        }
    }
