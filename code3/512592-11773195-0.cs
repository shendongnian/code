    public interface IViewModel
    {
    }
    public class ViewModelOne : IViewModel
    {
    }
    public class ViewModelTwo : IViewModel
    {
    }
    public class SiteMapper 
	{
        private Dictionary<Site, List<IViewModel>> map { get; set; }
        public void Register(Site site, IViewModel viewModel)
        {
            // Add combination to map
        }
	    public List<IViewModel> MapDomainToViews(Site site) 
        {
            if (map.ContainsKey(site))
                return map[site];
            else
                ....
        }
	}
