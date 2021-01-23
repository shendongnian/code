            public static void seeks()
        {
            long offset = 0;
            string streamsample = "";
            int numoflines = 0;
            using (FileStream fs = new FileStream(@"C:\Users\bussard\Documents\JamesTwork\SourceDatatoedit.csv", FileMode.Open, FileAccess.Read))
            {
                fs.Seek(offset, SeekOrigin.Begin);
                StreamReader sr = new StreamReader(fs);
                { //determines how many lines are in my file.
                    while (!sr.EndOfStream)
                    {
                        streamsample = sr.ReadLine();
                        numoflines++;
                    }// end while block
                    Console.WriteLine("Lines: " + numoflines);
                }//end stream sr block
                long[] dataArray = new long[numoflines]; //create a long array based on amount of lines
                fs.Seek(offset, SeekOrigin.Begin);
                StreamReader dr = new StreamReader(fs);
                {create an array of long values based on where new lines occur as pointers.
                    numoflines = 0;
                    streamsample = "";
                    while (!dr.EndOfStream)
                    {
                        streamsample = dr.ReadLine();
                        dataArray[numoflines] = offset;
                        offset += streamsample.Length - 1;
                        numoflines++;
                    }// end while
                    int j = 0;
                    while (j < numoflines)
                    { // displays the pointer and what data is at that point.
                        fs.Seek(dataArray[j], SeekOrigin.Begin);
                        Console.WriteLine("Pointer: " + dataArray[j].ToString() + " String: " + dr.ReadLine().ToString());
                        j++;
                    }//end while
                }//end streamReader dr block
            }//end filestream fs block
        }// end method seeks ()
