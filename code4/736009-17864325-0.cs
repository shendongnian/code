     for(int i = 0; i < lines.Length; i++)
       {
           String line = lines[i];
    
           Excel.Range c1 = (Excel.Range)xlWs.Cells[i+1, 1];
           Excel.Range c2 = (Excel.Range)xlWs.Cells[i+1, 1 + line.Length];
           Excel.Range range = xlWs.get_Range(c1, c2);
           string[] split = line.Split('\t');
           for (int c = 1; c <= split.Length; c++)
           {
              range.Cells[1, c] = split[c-1];
           }
       }
