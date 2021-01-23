    public void InsertMappings(XDocument xml, string templateName, Type typeToInsert)
    {
        // Here I find the relevent mappings 
        using (var repo = new Repository())
        {
            foreach (var m in mappings)
            {
                // XML -> Entity
                var mapping = (typeToInsert)Activator.CreateInstance(typeToInsert);
                (mapping as Mapping).MappedValue = m.Value;
                (mapping as Mapping).OriginalValue = GetCode(m);
                // Update database
                repo.Insert(mapping);
            }
            repo.Save();
       }
    }
