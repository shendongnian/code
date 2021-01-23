     List<string> strings = new List<string>()
                {
                    "A",
                    "B",
                    "C_DELETED",
                    "E_DELETED",
                    "D",
                    "C_DELETED",
                };
    
     var result = strings.OrderBy(i => i.Replace("_DELETED", string.Empty));
