     using (var csv = new CsvReader(new StreamReader(filePath, Encoding.Default)))
     {
                csv.Configuration.Delimiter = ';'; 
                csv.Configuration.ClassMapping<LogHeaderMap, LogHeader>(); 
                
                var data = csv.GetRecords<LogHeader>();
                foreach (var entry in data.OrderByDescending(x => x.Date))
                {
                   //process
                }
     }
