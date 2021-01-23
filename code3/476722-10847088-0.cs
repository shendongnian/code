     public interface IExcelReporting : IServiceObject
        {
            ColumnsExcel Columns { get; }
    
            void SetDatasource(IEnumerable datasource);
            void SetHeaderLabelMerge(int columnMerge);
            void AddHeader(string label, string value);
            Byte[] ExportToExcel(string title, string author, DateTime date);
        }
