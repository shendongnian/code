    public string SearchCriteria
    {
         get
         {
             return searchCriteria;
         }
         set
         {   
             serchCriteria = value;
             RaisePropertyChanged("SearchCriteria");
             RaisePropertyChanged("FooList");
         }
    }
    private List<Foo> fooList;
    
    public List<Foo> FooList
    {
        get 
        {
           return fooList.Where(x => x.Name.Contains(searchCriteria)); 
        }
    }
