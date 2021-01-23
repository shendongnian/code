            using (var excelPkg = new ExcelPackage())
            {
                var name = "Sheet1";
                //You will probably pass the columns to output into this function
                var headerArray = new string[] { "Column1", "Column2" };
                var data = positions
                    .Select(i => headerArray.Select(h => GetValue(i, h)).ToArray());
                var ws = excelPkg.Workbook.Worksheets.Add(name);
                ws.Cells["A1"].LoadFromArrays(
                    ((object[])headerArray).ToSingleItemEnumerable().Union(data));
                ws.Row(1).Style.Font.Bold = true; //set header to bold
                excelPkg.SaveAs(stream, "password");
            }
        private static object GetValue(Position item, string field)
        {
            //Your logic goes here
            return null;
        }
        public static IEnumerable<T> ToSingleItemEnumerable<T>(this T o)
        {
            yield return o;
        }
