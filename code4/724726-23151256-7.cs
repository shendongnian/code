      public static string OxbridgeAnd(this IEnumerable<string> collection)
        {
            var output = string.Empty;
    
            if (collection == null) return null;
    
            var list = collection.ToList();
    
            if (!list.Any()) return output;
    
            if (list.Count == 1) return list.First();
    
            var delimited = string.Join(", ", list.Take(list.Count - 1));
    
            output = string.Concat(delimited, ", and ", list.LastOrDefault());
    
            return output;
        }
