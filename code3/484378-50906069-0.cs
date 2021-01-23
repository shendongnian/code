                {
                    int s = 0, e = 0;
    
                    for (; e < line.Length; e++)
                    {
                        if (line[e] == '\n')
                        {
                            // \n always terminates a line.
    
                            lines.Add(line.Substring(s, (e - s) + 1));
    
                            s = e + 1;
                        }
                        if (line[e] == '\r' && (e < line.Length - 1))
                        {
                            // \r only terminates a line if it isn't followed by \n.
    
                            if (line[e + 1] != '\n')
                            {
                                lines.Add(line.Substring(s, (e - s) + 1));
    
                                s = e + 1;
                            }
                        }
                    }
                    
                    // Check for trailing characters not terminated by anything.
    
                    if (s < e)
                    {
                        lines.Add(line.Substring(s, (e - s)));
                    }
                }
