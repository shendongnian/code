    DataTable DT = ...
    // Rename column to OLD:
    DT.Columns["ID"].ColumnName = "ID_OLD";
    // Add column with new type:
    DT.Columns.Add( "ID", typeof(int) );
    // copy data from old column to new column with new type:
    foreach( DataRow DR in DT.Rows )
    { DR["ID"] = Convert.ToInt32( DR["ID_OLD"] ); }
    // remove "OLD" column
    DT.Columns.Remove( "ID_OLD" );
