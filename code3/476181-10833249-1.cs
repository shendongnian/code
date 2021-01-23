        public IQueryable<T> GetRequestByCustomQuery<T>(string strql)
            where T :  RequestBase
        {
             return _context
                   .RequestBases
                   .OfType<T>()   //
                   .Where(strql);
        }
