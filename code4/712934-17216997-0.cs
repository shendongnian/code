    var temp = collection.FirstOrDefault(x =>
        {
            if (x.Name != null)
            {
                // this part returns bool
                return x.Name.ToString().Equals(s);
            }
            else
            {
                // this one returns string
                return x.Name;
            }
        });
