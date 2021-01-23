        public static string GetSimplifiedRangeString(List<CellRef> cellList)
        {
            #region Column wise simplify (identify lines)
            Dictionary<CellRef, CellRef> rowRanges = new Dictionary<CellRef, CellRef>(new CellRefEqualityComparer());
            
            int currentRangeStart = 0;
            for (int currentRangeStop = 0; currentRangeStop < cellList.Count; currentRangeStop++)
            {
                CellRef currentCell = cellList[currentRangeStop];
                CellRef previousCell = (currentRangeStop == 0) ? null : cellList[currentRangeStop - 1];
                bool cont = IsContigousX(currentCell, previousCell);
                if (!cont)
                {
                    currentRangeStart = currentRangeStop;
                }
                if (!rowRanges.ContainsKey(cellList[currentRangeStart]))
                    rowRanges.Add(cellList[currentRangeStart], cellList[currentRangeStop]);
                else
                    rowRanges[cellList[currentRangeStart]] = cellList[currentRangeStop];
            }
            #endregion
            #region Row wise simplify (identify rectangles)
            List<CellRange> rangeList = new List<CellRange>();
            foreach (KeyValuePair<CellRef, CellRef> range in rowRanges)
            {
                rangeList.Add(new CellRange(range.Key, range.Value));                
            }            
            Dictionary<CellRange, CellRange> colRanges = new Dictionary<CellRange, CellRange>(new CellRangeEqualityComparer()); 
            
            currentRangeStart = 0;
            for (int currentRangeStop = 0; currentRangeStop < rangeList.Count; currentRangeStop++)
            {
                CellRange currentCellRange = rangeList[currentRangeStop];
                CellRange previousCellRange = (currentRangeStop == 0) ? null : rangeList[currentRangeStop - 1];
                bool cont = IsContigousY(currentCellRange, previousCellRange);
                if (!cont)
                {
                    currentRangeStart = currentRangeStop;
                }
                if (!colRanges.ContainsKey(rangeList[currentRangeStart]))
                    colRanges.Add(rangeList[currentRangeStart], rangeList[currentRangeStop]);
                else
                    colRanges[rangeList[currentRangeStart]] = rangeList[currentRangeStop];
            }
            #endregion
            #region Simplify ranges (identify atomic lines and rectangles)
            StringBuilder retStr = new StringBuilder();
            foreach (KeyValuePair<CellRange, CellRange> ranges in colRanges)
            {
                string rangePart = string.Empty;
                if (ranges.Key.Equals(ranges.Value))
                {
                    if (ranges.Key.Start.Equals(ranges.Key.Stop))
                    {
                        rangePart = ranges.Key.Start.ToString();
                    }
                    else
                    {
                        rangePart = ranges.Key.ToString();
                    }
                }
                else
                {
                    rangePart = new CellRange(ranges.Key.Start, ranges.Value.Stop).ToString();
                }
                if (retStr.Length == 0)
                {
                    retStr.Append(rangePart);
                }
                else
                {
                    retStr.Append("," + rangePart);
                }
            }
            return retStr.ToString();
            #endregion
        }
        /// <summary>
        /// Checks whether the given two cells represent a line.
        /// </summary>
        /// <param name="currentCell">Line start</param>
        /// <param name="previousCell">Line end</param>
        /// <returns></returns>
        private static bool IsContigousX(CellRef currentCell, CellRef previousCell)
        {
            if (previousCell == null)
                return false;
            return (currentCell.Row == previousCell.Row) && (currentCell.Col == (previousCell.Col + 1));
        }
        /// <summary>
        /// Checks whether the given two cells represents a rectangle.
        /// </summary>
        /// <param name="currentCellRange">Top-left cell</param>
        /// <param name="previousCellRange">Bottom-right cell</param>
        /// <returns></returns>
        private static bool IsContigousY(CellRange currentCellRange, CellRange previousCellRange)
        {
            if (previousCellRange == null)
                return false;
            bool sameVertically = (currentCellRange.Start.Col == previousCellRange.Start.Col) && (currentCellRange.Stop.Col == previousCellRange.Stop.Col);
            bool contigous = (currentCellRange.Start.Row == currentCellRange.Stop.Row) && (previousCellRange.Start.Row == previousCellRange.Stop.Row) && ((previousCellRange.Stop.Row + 1) == currentCellRange.Stop.Row);
            return sameVertically && contigous;
        }
