    public interface IFilterProvider
    {
        void AddFilters(FilterInfo filterInfo);
    }
    public abstract class FilterProvider : IFilterProvider
    {
        public void AddFilters(FilterInfo filterInfo)
        {
            if (this is IActionFilter)
            {
                filterInfo.ActionFilters.Add(this as IActionFilter);
            }
        }
    }
