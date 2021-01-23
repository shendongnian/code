        public IQueryable<RequestBase> GetRequestByCustomQuery(string strql)
        {
             return _context
                   .RequestBases
                   .OfType<EcoBonusRequest>()   //
                   .Where(strql);
        }
