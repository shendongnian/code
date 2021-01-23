        public class TimelogQueryTranslator : QueryTranslator
        {
        public ObjectQuery<Timelog> Translate(Query query)
        {
            ObjectQuery<Timelog> timelogQuery;
            if (query.IsNamedQuery())
            {
                timelogQuery = FindEFQueryFor(query);
            }
            else
            {
                StringBuilder queryBuilder = new StringBuilder();
                IList<ObjectParameter> paraColl = new List<ObjectParameter>();
                CreateQueryAndObjectParameters(query, queryBuilder, paraColl);
                //[Edited By= Iman] :
                if (query.OrderByProperty == null)
                {
                    timelogQuery = DataContextFactory.GetDataContext().Timelogs
                    .Where(queryBuilder.ToString(), paraColl.ToArray());
                }
                else if (query.OrderByProperty.Desc == true)
                {
                    timelogQuery = DataContextFactory.GetDataContext().Timelogs
                    .Where(queryBuilder.ToString(), paraColl.ToArray()).OrderBy(String.Format("it.{0} desc", query.OrderByProperty.PropertyName));
                }
                else
                {
                    timelogQuery = DataContextFactory.GetDataContext().Timelogs
                        .Where(queryBuilder.ToString(), paraColl.ToArray()).OrderBy(String.Format("it.{0} asc", query.OrderByProperty.PropertyName));
                }
                //[Edited By= Iman] .
                
            }
            return timelogQuery;
        }
        //-------------------------------------------------------------
            public abstract class QueryTranslator
        {
            public void CreateQueryAndObjectParameters(Query query, StringBuilder queryBuilder, IList<ObjectParameter> paraColl)
            {
                bool _isNotFirstFilterClause = false;
                foreach (Criterion criterion in query.Criteria)
                {
                    if (_isNotFirstFilterClause)
                    {
                        queryBuilder.Append(" AND "); //TODO: select depending on query.QueryOperator
                    }
                    switch (criterion.criteriaOperator)
                    {
                        case CriteriaOperator.Equal:
                            queryBuilder.Append(String.Format("it.{0} = @{0}", criterion.PropertyName));
                            break;
                        case CriteriaOperator.LesserThanOrEqual:
                            queryBuilder.Append(String.Format("it.{0} <= @{0}", criterion.PropertyName));
                            break;
                        default:
                            throw new ApplicationException("No operator defined");
                    }
                    paraColl.Add(new ObjectParameter(criterion.PropertyName, criterion.Value));
                    _isNotFirstFilterClause = true;
                }
            }
        }
