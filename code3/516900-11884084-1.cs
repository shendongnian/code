    using(var file = File.OpenText(path)) {
        string line;
        while((line = file.ReadLine()) != null) {
            // process this line
            alResult = CSVParser(line, txtDelimiter, txtQualifier);
            for (int i = 0; i < alResult.Count; i++)
            {
                drRow[i] = alResult[i];
            }
            dtResult.Rows.Add(drRow);
        }
    }
