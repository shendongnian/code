    addressBookEntryIds.Split(new[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries)
                       .Where(id => 
                       {
                           long val;
                           return Int64.TryParse(id, out val);
                       })
                       .Select(id => Int64.Parse(id));
