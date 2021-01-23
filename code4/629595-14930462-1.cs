    private void ShipRecords()
        {
            StreamWriter writer;
            StreamReader reader;
            try
            {
                writer = new StreamWriter(outputFile);
                reader = new StreamReader(inputFile);
                string line;
                string[] columns;
                while ((line = reader.ReadLine()) != null)
                {
                    columns = line.Split('\t'); // you may want to check that you get the correct number of columns etc.
                    if (columns[0] == "A" && PublishRecord(columns))
                        columns[0] = "P";
                    writer.WriteLine(String.Join("\t", columns));
                }
            }
            catch { }
            finally
            {
                try { writer.Close(); }
                catch { }
                try { reader.Close(); }
                catch { }
            }
        }
