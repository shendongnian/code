    private static readonly IDictionary<string,Action<string>> actionByType =
        new Dictionary<string,Action<string>> {
            {"ReadFile", ReadFile}
        ,   {"ReadMSOfficeWordFile", ReadMSOfficeWordFile}
        ,   {"ReadMSOfficeExcelFile", ReadMSOfficeExcelFile}
        ,   {"ReadPDFFile", ReadPDFFile}
        };
