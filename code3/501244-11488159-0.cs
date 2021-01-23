            while ((line = sr.ReadLine()) != null)
            {
                string[] values = line.Split(new string[] { " , " }, StringSplitOptions.None);
                for (int i = 0; i < values.Length; i++)
                {
                    valArr[LineCount, i] = Int64.Parse(values[i]);
                }
                LineCount++;
            }
