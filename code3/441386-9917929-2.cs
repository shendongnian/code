    public ICollection<IResultClass> ConvertAnything(ICollection collection)
        {
            var x = collection.Cast<IResultClass>();
            return x.ToList();
        }
