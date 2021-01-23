        public void Texts(FileInfo srcFile, DirectoryInfo outDir, string splitter = "dipendent")
        {
            // open file reader
            using (StreamReader srcRdr = new StreamReader(srcFile.FullName))
            {
                int outFileIdx = 1;
                StreamWriter outWriter = new StreamWriter(outDir.FullName + srcFile.Name + outFileIdx + ".txt");
                while (!srcRdr.EndOfStream)  //  read lines one by one untill ends
                {
                    string readLine = srcRdr.ReadLine();
                    int indexOfSplitter = readLine.IndexOf(splitter, StringComparison.Ordinal); // find splitter
                    if(indexOfSplitter >= 0) // if there is a splitter
                    {
                        outWriter.WriteLine(readLine.Substring(indexOfSplitter)); // write whats before...
                        //outWriter.WriteLine(readLine.Substring(indexOfSplitter) + splitter.Length); // use if you want splitting text to apear in the end of the previous file
                        outWriter.Close(); // close the current file
                        outWriter.Dispose();
                        // update the Text to be written to exclude what's already written to the current fils
                        readLine = readLine.Substring(indexOfSplitter); 
                        //readLine = readLine.Substring(indexOfSplitter + splitter.Length);  // Use if you want splitting text to apear in the new file
                        // OPEN NEXT FILE
                        outFileIdx++; 
                        outWriter = new StreamWriter(outDir.FullName + srcFile.Name + outFileIdx + ".txt");
                    }
                    outWriter.WriteLine(readLine);
                }
                outWriter.Close();
                outWriter.Dispose();
            }
        }
