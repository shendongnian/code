            int currentLine = 0;
            using (StreamReader reader = new StreamReader(sqlConnectionString))
            {
                using (StreamWriter writer = new StreamWriter(saveFileDialog1.FileName))
                {
                    while ((line = reader.ReadLine()) != null)
                    {
                        currentLine++;
                        if (currentLine < 110 || currentLine > 201)
                        {
                            writer.WriteLine(line);
                        }
                    }
                }
            }
