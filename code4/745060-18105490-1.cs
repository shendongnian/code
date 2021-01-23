    // you can substitute this with Directory.GetFiles
    var files = new []
    {
    	"BkUpSalesReportJan2011(txt).zip",
    	"BkUpSalesReportJan2011(pdf).zip",
    	"BkUpSalesReportJan2011(doc).zip",
    	"BkUpSalesReportFeb2011(txt).zip",
    	"BkUpSalesReportMar2011(doc).zip",
    	"BkUpSalesReportMar2011(pdf).zip"
    };
    
    var pattern = @"(?<FileName>.+)\((?<FileType>\w+)\)\.zip";
    // (?<FileName>.+) Match the first part in a named group
    // \( Match the first open parenthesis
    // (?<FileType>\w+) Match the txt/pdf/doc/whatever in a named group
    // \) Match the closing parenthesis
    // \.zip Match a period followed by the zip
    
    var matchedFiles = files.Select(f => Regex.Match(f, pattern))
                            .Where(m => m.Success)
                            .Select(f =>
                                new FileData
                                    {
                                        Type = f.Groups["FileType"].Value,
                                        Name = f.Groups["FileName"].Value,
                                        Original = f.Value
                                    }
                                   ).ToList();
    
    var distinct = matchedFiles.GroupBy(f => f.Name)
                               .Select(g => g.OrderBy(f => f.Weight).First())
                               .Select(f => f)
                               .Select(f => f.Original);
    
    var duplicates = matchedFiles.GroupBy(f => f.Name)
                                 .Select(g => g.OrderBy(f => f.Weight).Skip(1))
                                 .SelectMany(g => g)
                                 .Select(f => f.Original);
