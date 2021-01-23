    // load a StreamReader to the old path
    using (StreamReader sr = new StreamReader(oldPath)) 
    {
        // load a StreamWriter to the new path
        using (StreamWriter sw = new StreamWriter(newPath)) 
        {
            string lastLine = string.empty();
            while (sr.Peek() >= 0) 
            {
                var line = sr.ReadLine();
                // if the line's text is different from the previous, write it
                if (line != lastLine)
                {            
                    sw.WriteLine(line);
                    lastLine = line
                }
            }
        }
    }
