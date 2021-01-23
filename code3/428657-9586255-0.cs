    private static readonly IDictionary<string,Action<FileInfo>> actionByType =
        new Dictionary<string,Action<FileInfo>> {
            {"ReadFile", ReadFile}
        ,   {"ReadMSOfficeWordFile", ReadMSOfficeWordFile}
        ,   {"ReadMSOfficeExcelFile", ReadMSOfficeExcelFile}
        ,   {"ReadPDFFile", ReadPDFFile}
        };
