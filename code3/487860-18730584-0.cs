        // Somewhere around an interface
        class ColumnSortItem
        {
            string Caption { get; set; }
            SortOrder Order { get; set; }
        }
        // Other places:
        void SortByColumns(IList<ColumnSortItem> pColumnSortItems);
