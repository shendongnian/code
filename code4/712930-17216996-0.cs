    var temp = collection.FirstOrDefault(x =>
        {
            if (x.Name != null)
            {                
                return x.Name.ToString().Equals(s);
            }
            else
            {
                // instead of return x.Name which is string
                return false;
            }
        });
