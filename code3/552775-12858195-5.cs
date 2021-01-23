    public void InsertMappings<T>(XDocument xml, string templateName)
    {
        // Here I find the relevent mappings 
        using (var repo = new Repository())
        {
            foreach (var m in mappings)
            {
                // XML -> Entity
                var mapping = (T)Activator.CreateInstance(typeof(T));
                (mapping as Mapping).MappedValue = m.Value;
                (mapping as Mapping).OriginalValue = GetCode(m);
                // Update database
                repo.Insert(mapping);
            }
            repo.Save();
       }
    }
