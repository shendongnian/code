    using System.Linq;
    using OfficeOpenXml;
    namespace Project.Extensions.Excel
    {
        public class ExcelWorksheetExtension
        {
            /// <summary>
            ///     Get Header row with EPPlus. 
            ///     <a href="https://stackoverflow.com/questions/10278101/epplus-reading-column-headers">
            ///         EPPlus Reading Column Headers
            ///     </a>
            /// </summary>
            /// <param name="sheet"></param>
            /// <returns>Array of headers</returns>
            public static string[] GetHeaderColumns(this ExcelWorksheet sheet)
            {
                return sheet.Cells[sheet.Dimension.Start.Row, sheet.Dimension.Start.Column, 1, sheet.Dimension.End.Column]
                    .Select(firstRowCell => firstRowCell.Text).ToArray();
            }
        }
    }
