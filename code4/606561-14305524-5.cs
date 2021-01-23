    using (DataTable table = new DataTable()) {
    
    	using (OleDbDataAdapter adapter = new OleDbDataAdapter("select name,age from person", conObject)) {
    
    		adapter.Fill(table);
    		BindingSource bs = new BindingSource { DataSource = table };
    		dgReader.DataSource = bs;    
    	}
    
    }
