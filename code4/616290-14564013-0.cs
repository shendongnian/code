    var query = (from c in ordering(db_cooperations.cooperations)
                             select new { c.id, c.name, c.phone, c.email, c.city })
                             .Skip(numberOfObjectsPerPage * page).Take(numberOfObjectsPerPage);
    
    if (String.IsNullOrEmpty(searchTxt.Text) == false && searchTxt.Text.Trim() != "Search....")
    	{
    		query = from c in query
            where c.name.ToLower().Contains(searchTxt.Text.ToLower())
            select new { c.id, c.name, c.phone, c.email, c.city })
    	}
    
    if (kotaCB.SelectedIndex > -1)
    	{
    		query = from c in query
    				where c.kota.ToLower().Equals(kotaCB.Text.ToLower())
                    select new { c.id, c.name, c.phone, c.email, c.city });
    		}
    
    dataGridView1.DataSource = query.ToList();
