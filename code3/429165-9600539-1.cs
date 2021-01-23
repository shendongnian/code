        public List<CSVRows> parsecsv(string csvpath)
        {
            Encoding iso = Encoding.GetEncoding("ISO-8859-1");                       
            using (CachedCsvReader csv = new CachedCsvReader(new StreamReader(csvpath, iso), true))                       
            {                       
                csv.MissingFieldAction = MissingFieldAction.ReplaceByEmpty;                       
                // I have no idea what this method is but if it exists it could be called ToList or Read    
                return csv.ToList<CSVRows>();                       
            } 
        }
