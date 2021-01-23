            public T RandomChoice<T> (IEnumerable<T> source)
            {
                if (source == null)
                {
                    throw new ArgumentNullException("source");
                }
    
                var list = source.ToList();
    
                if (list.Count < 1)
                {
                    throw new MissingMemberException();
                }
    
                var rnd = new Random();
                return list[rnd.Next(0, list.Count)];
            }
