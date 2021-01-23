        private string CompactRangeStringByRows(string strCellRange)
        {
            SortedDictionary<int, SortedList<char, char>> rows = new SortedDictionary<int, SortedList<char, char>>();
            foreach (string aCell in strCellRange.Split(new Char[] { ',' }))
            {
                char col = aCell[0];
                int row = int.Parse(aCell.Substring(1, aCell.Length - 1));
                SortedList<char, char> cols;
                if (!rows.TryGetValue(row, out cols))
                {
                    cols = new SortedList<char, char>();
                    rows[row] = cols;
                }
                cols.Add(col, col);
            }
            StringBuilder sb = new StringBuilder();
            bool first = true;
            foreach (KeyValuePair<int, SortedList<char, char>> rowCols in rows)
            {
                char minCol = '0';
                char maxCol = '0';
                foreach (char col in rowCols.Value.Keys)
                {
                    if (minCol == '0')
                    {
                        minCol = col;
                        maxCol = col;
                    }
                    else
                    {
                        if (col == maxCol + 1)
                            maxCol = col;
                        else
                        {
                            AddRangeString(sb, first, rowCols.Key, minCol, maxCol);
                            minCol = col;
                            maxCol = col;
                            first = false;
                        }
                    }
                }
                AddRangeString(sb, first, rowCols.Key, minCol, maxCol);
                first = false;
            }
            return sb.ToString();
        }
        private void AddRangeString(StringBuilder sb, bool first, int row, char minCol, char maxCol)
        {
            if (!first)
                sb.Append(',');
            sb.Append(minCol);
            sb.Append(row);
            if (maxCol != minCol)
            {
                sb.Append(':');
                sb.Append(maxCol);
                sb.Append(row);
            }
        }
