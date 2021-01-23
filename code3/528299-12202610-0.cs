    public class MainViewModel
    {
    	public MainViewModel()
    	{
            //Create some fake data 
    		InnerStaff = new ObservableCollection<StaffViewModel>();
    		InnerStaff.Add(new StaffViewModel {FirstName = "Sue", LastName = "Bucknell"});
    		InnerStaff.Add(new StaffViewModel {FirstName = "James", LastName = "Bucknell"});
    		InnerStaff.Add(new StaffViewModel {FirstName = "John", LastName = "Harrod"});
    
    		CvsStaff = new CollectionViewSource();
    		CvsStaff.Source = this.InnerStaff;
    		CvsStaff.Filter += ApplyFilter;
    	}
    
    	private string filter;
    
    	public string Filter
    	{
    		get { return this.filter; }
    		set
    		{
    			this.filter = value;
    			OnFilterChanged();
    		}
    	}
    
    	private void OnFilterChanged()
    	{
    		CvsStaff.View.Refresh();
    	}
    
    	internal ObservableCollection<StaffViewModel> InnerStaff { get; set; }
    	internal CollectionViewSource CvsStaff { get; set; }
    	public ICollectionView AllStaff
    	{
    		get { return CvsStaff.View; }
    	}
    
    	void ApplyFilter(object sender, FilterEventArgs e)
    	{
    		StaffViewModel svm = (StaffViewModel)e.Item;
    
    		if (string.IsNullOrWhiteSpace(this.Filter) || this.Filter.Length == 0)
    		{
    			e.Accepted = true;
    		}
    		else
    		{
    			e.Accepted = svm.LastName.Contains(Filter);
    		}
    	}
    }
