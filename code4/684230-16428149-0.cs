    ExcelQueryFactory excel = new ExcelQueryFactory(FilePath);
    List<STC> stResults = (from s
                           in excel.Worksheet<STC>("StaticResults")
                           select s)
                           .ToList();
    
    List<DYN> dynResults = (from s
                            in excel.Worksheet<DYN>("DynamicResults")
                            select new {Property1 = s.xxx, Property2 = S.yyy)      //get the props based on the type of S
                            .ToList();
