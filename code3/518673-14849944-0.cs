        private void ProcessFile(string inputFileName, string outputFileName)
        {
            using (StreamReader reader = new StreamReader(inputFileName, new UTF8Encoding(false, true)))
            {
                using (StreamWriter writer = new StreamWriter(outputFileName, false, Encoding.UTF8))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        const string xmlDeclarationStart = "<?xml";
                        const string xmlDeclarationFinish = "?>";
                        if (line.Contains(xmlDeclarationStart))
                        {
                            string newLine = line.Substring(0, line.IndexOf(xmlDeclarationStart));
                            int endPosition = line.IndexOf(xmlDeclarationFinish, line.IndexOf(xmlDeclarationStart));
                            if (endPosition == -1)
                            {
                                throw new NotImplementedException(string.Format("Implementation assumption is wrong. {0} .. {1} spans multiple lines (or input file is severely misformed)", xmlDeclarationStart, xmlDeclarationFinish));
                            }
                            // the code completely strips the <?xml ... ?> part
                            // an alternative would be to make this a new XML element containing
                            // the information inside the <?xml ... ?> part as attributes
                            // just like Daren Thomas suggested
                            newLine += line.Substring(endPosition + 2);
                            line = newLine;
                        }
                        writer.WriteLine(line);
                    }
                }
            }
        }
