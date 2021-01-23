    foreach (var restriction in BaseList.Createrestrictions(parameter))
    {
        t.Where(restriction);
    }
    public class BaseList
    {
        public IEnumerable<AbstractCriterion> Createrestrictions(List<MMPFramework.SearchParameter> parameter)
        {
            return parameter.Select(ToCritieria);
        }
        private AbstractCriterion ToCritieria(SearchParameter searchParameter)
        {
            if(searchParameter.Expression == "Like")
            {
                return Restrictions.Like(searchParameter.PropertyName, searchParameter.ObjectValueLo);
            }
            else ...
        }
    }
