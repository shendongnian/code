    /// <summary>
            /// Merges the cells together.
            /// </summary>
            /// <param name="worksheet">The worksheet.</param>
            /// <param name="cellsToMerge">The cells to merge.</param>
            /// <exception cref="System.ArgumentNullException">ws;Worksheet has to be defined</exception>
            /// <exception cref="System.ArgumentException">Cells cannot contain null or empty string;cellsToMerge</exception>
            public void MergeCellsTogether(Worksheet worksheet, string cellsToMerge)
            {
                if(worksheet==null) throw new ArgumentNullException("worksheet","Worksheet has to be defined");
                if(string.IsNullOrEmpty(cellsToMerge))throw new ArgumentException("Cells cannot contain null or empty string", "cellsToMerge");
                
                worksheet.Range[cellsToMerge].Merge();
            }
