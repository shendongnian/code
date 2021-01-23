    class CustomSorter
    {
        static Dictionary<string, Func<IMyClass, object>> Selectors;
    
        static CustomSorter()
        {
            Selectors = new Dictionary<string, Func<IMyClass, object>>
            {
                { "letter", new Func<IMyClass, object>(x => x.Letter) },
                { "number", new Func<IMyClass, object>(x => x.Number) }
            };
        }
    
        public void Sort(IEnumerable<IMyClass> list, string sortField, bool isAscending)
        {
            Func<IMyClass, object> selector;
            if (!Selectors.TryGetValue(sortField, out selector))
            {
                throw new ArgumentException(string.Format("'{0}' is not a valid sort field.", sortField));
            }
    
            // Using extension method defined above.
            return list.Order(selector, isAscending);
        }
    }
