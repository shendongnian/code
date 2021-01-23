    ...
            new List<Tuple<String, Int32, String, Regex>>()
    ...
                           while ((line = reader.ReadLine()) != null)
                           {
                               Regex matchingReg = patterns.FirstOrDefault(pattern => pattern.IsMatch(line));
                               
                               if (keywords.Any(keyword => line.ToLower().Contains(keyword.ToLower())) || matchingReg != null)
                               {
                                   //cleans up the file path for grid
                                   string tmpfile = file.Replace(txtSelectedDirectory.Text, "..");
                                   accumulator.Add(Tuple.Create(tmpfile, counter, line, matchingReg));
                               }
                               counter++;
                           }
    ...
