    public class MainForm:Form
    {
    	private SearchForm searchForm;//for keeping the search form
    	public MainForm()//your main form constructor
    	{
    		
    	}
    	this.searchBtn.Click+=(s,e)=>
    	{
    		if(this.searchForm == null)
    		{
    			this.searchForm = new SearchForm(this);//creating new searchForm if it does no exist
    			this.searchForm.Show();
    			this.Enabled = false;
    		}
    		
    	};
    
    }
    
    public class SearchForm:Form
    {
    	private MainForm mainForm;//this will keep the original mainform
    	public SearchForm(MainForm mainForm)
    	{
    		this.mainForm = mainForm;
    	}
    	
    	this.OnFormClosing+=(s,e)=>
    	{
    		this.mainForm.Enabled = true;	
    	};
    }
