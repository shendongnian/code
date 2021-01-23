    using (StreamReader sr = new StreamReader(path))
    {
        // Initialize to null so we are not stuck in loop forever in case there is nothing in the file to read
        String line = null;
        do 
        {
            line = sr.ReadLine();
            // Is this the end of the file?
            if (line == null)
            {
                // Yes, so bail out of loop
                return;
            }
            // Is the line empty?
            if (line == String.Empty)
            {
                // Yes, so skip it
                continue;
            }
            // Here you process the non-empty line
        } while (true);
    }
