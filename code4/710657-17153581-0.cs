    var values =
        list.Select(
            s => {
                double value; 
                if(s == null || !Double.TryParse(s, out value)) {
                    return (double?)null;
                }
                return value;
            }
        ).ToList();
