    public static List<string> GetNCComments(Stream stream)
    {
        using (StreamReader sr = new StreamReader(stream))
        {
            List<string> result = new List<string>();
            bool inCS = false; // are we in C# code?
            int c;
            while ((c = sr.Read()) != -1)
            {
                if (inCS)
                {
                    switch ((char)c)
                    {
                        case '#':
                            if (sr.Peek() == '>') // end of C# block
                            {
                                sr.Read();
                                inCS = false;
                            }
                            break;
                        case '/':
                            if (sr.Peek() == '/') // a C# comment
                                sr.ReadLine(); // skip the whole comment
                            break;
                    }
                }
                else
                {
                    switch ((char)c)
                    {
                        case '<':
                            if (sr.Peek() == '#') // start of C# block
                            {
                                sr.Read();
                                inCS = true;
                            }
                            break;
                        case ';': // NC comment
                            string comment = sr.ReadLine();
                            if (!string.IsNullOrEmpty(comment))
                                result.Add(comment);
                            break;
                    }
                }
            }
            return result;
        }
    }
