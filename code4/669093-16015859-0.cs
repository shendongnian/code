     class Program
    {
        private List<string> _dummyText = new List<string>(){ "Arda",
            "Araba",
            "Antartika",
            "Balon"};
        static void Main(string[] args)
        {
            Program p = new Program();
            List<string> result = p.Get(s => s.StartsWith("A"), orderBy: q => q.OrderBy(d => d.Length)).ToList();
            Console.ReadLine();
        }
        public virtual IEnumerable<string> Get(
        Expression<Func<string, bool>> filter = null,
        Func<IQueryable<string>, IOrderedQueryable<string>> orderBy = null)
        {
            IQueryable<string> query = _dummyText.AsQueryable();
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
            
        }
    }
