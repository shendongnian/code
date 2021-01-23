    public static void Merge(string inFile1, string inFile2, string outFile) 
    {
        string line1 = null;
        string line2 = null;
        using (StreamReader sr1 = new StreamReader(inFile1))
        {
            using (StreamReader sr2 = new StreamReader(inFile2))
            {
                using (StreamWriter sw = new StreamWriter(outFile))
                {
                    line1 = sr1.ReadLine();
                    line2 = sr2.ReadLine();
                    while(line1 != null && line2 != null)
                    {
                        // your comparison function here
                        // ex: (line1[0] < line2[0])
                        if(line1 < line2)
                        {
                            sw.WriteLine(line1);
                            line1 = sr1.ReadLine();
                        }
                        else 
                        {
                            sw.WriteLine(line2);
                            line2 = sr2.ReadLine();
                        }
                    }
                    while(line1 != null)
                    {
                        sw.WriteLine(line1);
                        line1 = sr1.ReadLine();
                    }
                    while(line2 != null)
                    {
                        sw.WriteLine(line2);
                        line2 = sr2.ReadLine();
                    }
                }
            }
        }
    }
