    class SelectionTableEntry
    {
        public bool cbIsChecked { get; set; }    
        public Table Table { get; set; }    
        public string TableName { get; set; }    
        public string btnEditFilter { get; set; }
    
        public SelectionTableEntry(Table table, bool IsChecked)
        {
            this.Table = table;
            this.TableName = table.Name;
            this.cbIsChecked = IsChecked;
        }
    }
