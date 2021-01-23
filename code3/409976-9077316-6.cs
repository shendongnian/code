        public static WinCell FindCellByColumnAndValue(this WinTable table, int colIndex, string strCellValue, bool searchHeader = false)
        {
            Playback.PlaybackSettings.SmartMatchOptions = Microsoft.VisualStudio.TestTools.UITest.Extension.SmartMatchOptions.None;
    
            WinCell cell = new WinCell(table);
            cell.SearchProperties.Add(WinCell.PropertyNames.ColumnIndex, colIndex.ToString());
            cell.SearchProperties.Add(WinCell.PropertyNames.Value, strCellValue);
    
            UITestControlCollection foundControls = cell.FindMatchingControls();
            if (foundControls.Count > 0)
            {
                cell = foundControls.List[0];
            }
            else
            {
                cell = null;
            }
            return cell;
        }
