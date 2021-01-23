        public IList<Ad> Search(string query)
        {
            return unitOfWork.Session
                .CreateCriteria<Ad>()
                .CreateAlias("Properties", "props")
                .Add(Expression.InsensitiveLike("props.Value", query, MatchMode.Anywhere))
                .List<Ad>();
        }
