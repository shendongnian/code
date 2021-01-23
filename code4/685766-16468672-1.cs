    string value = string.Empty;
    
    if(null!=ds) {
    if(null!=ds.Tables) {
    if(ds.Tables.Count > 0) {
    if(null!=ds.Tables[0].Rows) {
    if(ds.Tables[0].Rows.Count > 0) {
    if(null!=ds.Tables[0].Rows[0].Columns){
    if(ds.Tables[0].Rows[0].Columns.Count > 0)
    {
    value = ds.Tables[0].Rows[0].Columns[0].Value;
    }}}}}}}
