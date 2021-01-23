    public CachedCsvReader parsecsv(string csvpath)
        {   CachedCsvReader TempCSV = null;
            Encoding iso = Encoding.GetEncoding("ISO-8859-1");
            using (CachedCsvReader csv = new CachedCsvReader(new StreamReader(csvpath, iso), true))
            {
                csv.MissingFieldAction = MissingFieldAction.ReplaceByEmpty;
                TempCSV = csv;
            }
    
            return TempCSV;
        }
