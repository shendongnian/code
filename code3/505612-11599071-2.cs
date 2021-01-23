    public class Foo
    {
        public string Name { get; set; }
    }
    
    public string SearchCriteria
    {
         get
         {
             return searchCriteria;
         }
         set
         {   
             serchCriteria = value;
             FirePropertyChanged("SearchCriteria");
             FirePropertyChanged("FooList");
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
