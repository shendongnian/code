    public CachedCsvReader parsecsv(string csvpath)
        {   
            Encoding iso = Encoding.GetEncoding("ISO-8859-1");
            CachedCsvReader csv = new CachedCsvReader(new StreamReader(csvpath, iso), true)
            {
                csv.MissingFieldAction = MissingFieldAction.ReplaceByEmpty;
                return csv;
            }
        }
