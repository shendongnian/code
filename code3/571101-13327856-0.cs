        int Columns = 4;
        int LineLength = 80;
        public void WriteGroup(String[] group)
        {
            int columnWidth = LineLength / Columns;
            for (int i = 0; i < group.Length; i++)
            {
                if (i > 0 && i % Columns == 0)
                {
                    Console.WriteLine();
                }
                if (group[i].Length > columnWidth)
                {
                    Console.WriteLine(group[i].Substring(0, columnWidth));
                }
                else
                {
                    Console.Write(group[i].PadRight(columnWidth));
                }
            }
        }
