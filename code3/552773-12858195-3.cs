    public void InsertMappings<T>(XDocument xml, string templateName)
    {
        // Here I find the relevent mappings 
        using (var repo = new Repository())
        {
            foreach (var m in mappings)
            {
                // XML -> Entity
                var mapping = (Mapping)Activator.CreateInstance(typeof(T));
                mapping.MappedValue = m.Value;
                mapping.OriginalValue = GetCode(m);
                // Update database
                repo.Insert((T)mapping);
            }
            repo.Save();
       }
    }
