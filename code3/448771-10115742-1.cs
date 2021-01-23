    static class ListExtensions { 
        public static DataTable ToDataTable(this List<List<string>> list) { 
            DataTable tmp = new DataTable();
            tmp.Columns.Add("MyData");
            // Iterate through all List<string> elements and add each string value to a new DataTable Row.        
            list.ForEach(lst => lst.ForEach(s => tmp.Rows.Add(new object[] {s})));
    
            return tmp; 
        } 
    }
