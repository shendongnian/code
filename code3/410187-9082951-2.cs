    public interface IColumnExtractor
    {
        StringColumn GetPriceColumn(SearchAndExtractReply_2 source,
            string columnName);
    }
    public class ColumnExtractor : IColumnExtractor
    {
        public StringColumn GetPriceColumn(SearchAndExtractReply_2 source, 
            string columnName)
        {
            return (StringColumn)SearchAndExtractReply_2_Extension.GetColumn(source, 
                columnName);
        }
    }
