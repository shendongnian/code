    public void Sort() {
        if ( Comparer != null ) {
            InternalSort( Items.Skip( RowsToSkip ).OrderBy( item => item, Comparer ) );
        } else { 
            InternalSort( Items.Skip( RowsToSkip ).OrderBy( item => item ) );
        }
    }
