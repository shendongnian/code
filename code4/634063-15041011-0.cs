            string filePath = @"C:\input.txt";
            string outputDirectory = @"C:\";
            string[] allLines = File.ReadAllLines(filePath);
            
            // Replace multiple spaces with a single space character.
            for (int i = 0; i < allLines.Length; i++ )
            {
                allLines[i] = Regex.Replace(allLines[i], @"\s+", " ");
            }
            // Check how many columns there are.
            int columns = 0;
            if (allLines.Length > 0)
                columns = allLines[0].Split().Length;
            var linesValues = allLines.Select(l => l.Split());
            // Write each column to a separate file "output1.txt" ... "outputN.txt".
            for (int i = 0; i < columns; i++)
            {
                StringBuilder newTable = new StringBuilder();
                foreach (string[] values in linesValues)
                {
                    newTable.Append(values[i] + Environment.NewLine);
                }
                File.WriteAllText(outputDirectory + "output" + i + ".txt", newTable.ToString());
            }
