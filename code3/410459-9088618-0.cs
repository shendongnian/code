    public struct RowId {
        private int _rowId;
        public int Value{get{return _rowId;}}
        public RowId(int rowId) {_rowId = rowId;}
    }
    public int Get(RowId rowId, ColumnId columnId)
