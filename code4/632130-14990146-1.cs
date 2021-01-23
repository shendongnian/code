        public a Traverse(IQueryable<q> qList, string id)
        {
            return this.GatherAs(qList).FirstOrDefault(a => a.Id == id);
        }
        public IQueryable<a> GatherAs(IQueryable<q> qList)
        {
            IQueryable<a> aList = qList.SelectMany(q => q.aList);
            if (aList.Count != 0)
                aList = aList.Union(this.GatherAs(aList.SelectMany(a => a.qList)));
            return aList;       
        }
