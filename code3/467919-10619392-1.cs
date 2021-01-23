    using (StreamReader reader = new StreamReader( text ))
    {
        using (StreamWriter writer = new StreamWriter( file ))
        {
            while (( line = reader.ReadLine() ) != null)
            {
                int idx = line.IndexOf(line_to_delete);
                if (idx == 0) // just skip the whole line
                    continue;
                if (idx > 0)
                    writer.WriteLine(line.Substring(0, idx));
                else
                    writer.WriteLine(line);
            }
        }
    }
