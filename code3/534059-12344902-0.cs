    sourceData.Where(x => (x.SourceDate.Year > Invoice.StartDate.Year ||
                          (x.SourceDate.Month >= Invoice.StartDate.Month && 
                          x.SourceDate.Year == Invoice.StartDate.Year)) && 
                          (x.SourceDate.Year < Invoice.EndDate.Year ||
                          (x.SourceDate.Month <= Invoice.EndDate.Month &&
                          x.SourceDate.Year == Invoice.EndDate.Year))).ToList();
