        // edit
        private static TextReader PrepareReader(TextReader reader, out string outLine)
        {
    
    
            
                string line;
                string headerIdentifier = "&1,";
                while ((line = reader.ReadLine()) != null)
                {
                    // Check if the line starts with the header row identifier
                    if (line.Substring(0, 3) != headerIdentifier)
                    {
                        // ... do nothing
                    }
                    else
                    {
                        // edit
                        outLine = line;
                        break;
                    }
                }
          
        }
