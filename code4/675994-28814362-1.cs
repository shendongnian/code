System.IO;
System.Collection.Generic;
System.IO is for FileStream and StreamReader class to access your file. Both classes implement the IDisposable interface, so you can use the using statements to close your streams. (example below)
System.Collection.Generic namespace is for collections, such as IList,List, and ArrayList, etc... In this example, we'll use the List class, because Lists are better than Arrays in my honest opinion. However, before I return our outbound variable, i'll call the .ToArray() member method to return the array.
There are many ways to get content from your file, I personally prefer to use a while(condition) loop to iterate over the contents. In the condition clause, use !lReader.EndOfStream. While <b>not</b> end of stream, continue iterating over the file.
    public string[] GetCsvContent(string iFileName)
    {
        List<string> oCsvContent = new List<string>();
        using (FileStream lFileStream = 
                      new FileStream(iFilename, FileMode.Open, FileAccess.Read))
        {
            StringBuilder lFileContent = new StringBuilder();
            using (StreamReader lReader = new StreamReader(lFileStream))
            {
                // flag if a double quote is found
                bool lContainsDoubleQuotes = false; 
                // a string for the csv value
                string lCsvValue = "";
                // loop through the file until you read the end
                while (!lReader.EndOfStream)
                {
                    // stores each line in a variable
                    string lCsvLine = lReader.ReadLine();
                    // for each character in the line...
                    foreach (char lLetter in lCsvLine)
                    {
                        // check if the character is a double quote
                        if (lLetter == '"')
                        {
                            if (!lContainsDoubleQuotes)
                            {
                                lContainsDoubleQuotes = true;
                            }
                            else
                            {
                                lContainsDoubleQuotes = false;
                            }
                        }
                        // if we come across a comma 
                        // AND it's not within a double quote..
                        if (lLetter == ',' && !lContainsDoubleQuotes)
                        {
                            // add our string to the array
                            oCsvContent.Add(lCsvValue);
                            // null out our string
                            lCsvValue = "";
                        }
                        else
                        {
                            // add the character to our string
                            lCsvValue += lLetter;
                        }
                    }
                }
            }
        }
        return oCsvContent.ToArray();
    }
