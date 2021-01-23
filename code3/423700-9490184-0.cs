    static public void WorksheetToCSV(Excel.Worksheet origine, string CSVoutPath, string fieldSeparator, string textSeparator)
        {
            Excel.Range rngCurrentRow;
            string lineaDaScrivere;
            TextWriter csv = new StreamWriter(CSVoutPath);
            for (int i = 1; i <= origine.UsedRange.Rows.Count; i++)
            {
                rngCurrentRow = origine.UsedRange.get_Range("A" + i, "A" + i).EntireRow;
                lineaDaScrivere="";
                foreach (Excel.Range cella in rngCurrentRow.Columns)
                {
                    try
                    {
                        lineaDaScrivere = lineaDaScrivere + textSeparator + cella.Value.ToString() + textSeparator + fieldSeparator;
                    }
                    catch (NullReferenceException ex)
                    {
                        break;
                    }
                }
                lineaDaScrivere=lineaDaScrivere.Substring(0, (lineaDaScrivere.Length - fieldSeparator.Length));
               csv.WriteLine(lineaDaScrivere);
            }
            csv.Close();
        }
