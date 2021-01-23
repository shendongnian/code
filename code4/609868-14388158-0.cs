        static Info SearchMax(List<Info> list)
        {
            if (list.Count == 0)
            {
                throw new InvalidOperationException("Tomt Lista");
            }
            return list.OrderByDescending(i => i.Temperatur).FirstOrDefault();
        }
        static Info SearchMin(List<Info> list)
        {
            if (list.Count == 0)
            {
                throw new InvalidOperationException("Tomt Lista");
            }
             return list.OrderBy(i => i.Temperatur).FirstOrDefault();;
        }
