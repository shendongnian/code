            int LinesToKeep = 100;
            using (StreamReader reader = new StreamReader(sqlConnectionString))
            {
                using (StreamWriter writer = new StreamWriter(saveFileDialog1.FileName))
                {
                    for (int i = 1; (i <= LinesToKeep) && ((line = reader.ReadLine()) != null); i++)
                    {
                        writer.WriteLine(line);
                    }
                }
            }
