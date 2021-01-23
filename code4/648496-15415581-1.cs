    public class IndexViewModel
    {
	private string _search;
	public IndexViewModel(string search)
	{
		_search = search;
	}
	public AnalysisViewModel AnalysisViewModel
	{
		get
		{
			return new AnalysisViewModel(_search);
		}
	}
	public SlagViewModel SlagViewModel
	{
		get
		{
			return new SlagViewModel(_search);
		}
	}
