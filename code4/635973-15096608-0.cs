    public IEnumerable<Type> ExtractElements(IEnumerable<Type> list, IEnumerable<Type> specifiers) {
       var specifiersList = specifiers.ToList();
    
       return list.Where(t => specifiersList.Any(s => s.IsAssignableFrom(t));
    }
