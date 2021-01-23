        int Columns = 4;
        int LineLength = 80;
        public void WriteGroup(String[] group)
        {
            // determine the column width given the number of columns and the line width
            int columnWidth = LineLength / Columns;
            for (int i = 0; i < group.Length; i++)
            {
                if (i > 0 && i % Columns == 0)
                {   // Finished a complete line; write a new-line to start on the next one
                    Console.WriteLine();
                }
                if (group[i].Length > columnWidth)
                {   // This word is too long; truncate it to the column width
                    Console.WriteLine(group[i].Substring(0, columnWidth));
                }
                else
                {   // Write out the word with spaces padding it to fill the column width
                    Console.Write(group[i].PadRight(columnWidth));
                }
            }
        }
