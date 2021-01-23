    using System.Runtime.InteropServices;
    ...    
        /// <summary>
        /// <para>Customized function for Range property of Microsoft.Office.Interop.Excel.Worksheet</para>
        /// </summary>
        /// <param name="WS"></param>
        /// <param name="Cell1"></param>
        /// <param name="Cell2"></param>
        /// <returns>null if Range property of <paramref name="WS"/> throws exception, otherwise corresponding range</returns>
        public static Range GetRange(this Worksheet WS, object Cell1, [Optional] object Cell2)
        {
            try
            {
                return WS.Range[Cell1: Cell1, Cell2: Cell2];
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        ...
 
        Excel.Range sortRange = worksheet.GetRange("A14", "K32");
        Excel.Range scoreColumn = worksheet.GetRange("C14", "C32");
        // for this particular case, this check is unuseful
        // but if you set you scoreColumn as:
        // Excel.Range scoreColumn = worksheet.GetRange("COMPETITORS[[#Data], [SCORE]]");
        // you will have scoreColumn as null if COMPETITORS table has no column named "SCORE"
        if (sortRange != null && scoreColumn != null)
        {
            sortRange.Sort.SortFields.Clear();
            sortRange.Sort.SortFields.Add(scoreColumn,
                                          Excel.XlSortOn.xlSortOnValues, 
                                          Excel.XlSortOrder.xlDescending, 
                                          Type.Missing, 
                                          Excel.XlSortDataOption.xlSortNormal);
            sortRange.Sort.Header = XlYesNoGuess.xlYes;
            sortRange.Sort.MatchCase = false;
            // avoid setting this when you're dealing with a table
            // the only available option is xlSortColumns
            // if you apply a sort to a table and you set XlSortOrientation.xlRows, 
            // you will get an exception
            // see https://stackoverflow.com/questions/13057631/f-excel-range-sort-fails-or-rearranges-columns
            //sortRange.Sort.Orientation = XlSortOrientation.xlSortColumns;
            sortRange.Sort.SortMethod = XlSortMethod.xlPinYin;
            sortRange.Sort.Apply();
        }
