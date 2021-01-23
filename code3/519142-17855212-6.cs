        public IEnumerable<Timelog> GetAllTimelogsFor(int iadcId, byte workShift)
        {
            Query query = new Query(QueryName.Dynamic,new List<Criterion>());
            query.Add(Criterion.Create<Timelog>(t=>t.IadcId, iadcId, CriteriaOperator.Equal));
            query.QueryOperator = QueryOperator.And;
            query.Add(Criterion.Create<Timelog>(t=>t.Shift, workShift, CriteriaOperator.Equal));
            query.OrderByProperty = new OrderByClause { PropertyName = "FromTime", Desc = false };
            IEnumerable<Timelog> timelogs = _timelogRepository.FindBy(query);
            
            return timelogs;
        }
