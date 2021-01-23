    public interface IPivotTableCreator
    {
        void CreatePivotTable(
            OfficeOpenXml.ExcelPackage pkg, // reference to the destination book
            string tableName,               // "tab" name used to generate names for related items
            string pivotRangeName);         // Named range in the Workbook refers to data
    }
