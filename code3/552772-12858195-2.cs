    public void InsertMappings(XDocument xml, string templateName, Type typeToInsert)
    {
        // Here I find the relevent mappings 
        using (var repo = new Repository())
        {
            foreach (var m in mappings)
            {
                // XML -> Entity
                var mapping = (Mapping)Activator.CreateInstance(typeToInsert);
                mapping.MappedValue = m.Value;
                mapping.OriginalValue = GetCode(m);
                // Update database
                repo.Insert((typeToInsert)mapping);
            }
            repo.Save();
       }
    }
