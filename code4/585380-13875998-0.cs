    /// <summary>
        /// Delete all columns of specific bookmark
        /// </summary>
        /// <param name="bookmark"></param>
        public void DeleteTableColumns(string bookmark)
        {
            object oBookmark = bookmark;
            if (doc.Bookmarks.Exists(bookmark)) {
                object oCount = WdDeleteCells.wdDeleteCellsEntireColumn;
                doc.Bookmarks.get_Item(ref oBookmark).Select();
                app.Selection.Cells.Delete(ref oCount);
            }
        }
