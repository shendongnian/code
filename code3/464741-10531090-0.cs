            if (box != null)
            {                
                var dictionaryEntries = GetEntriesFromDatabase();
                box.DataSource = dictionaryEntries.Where(predicate);
                box.DataBind();
            }
}
