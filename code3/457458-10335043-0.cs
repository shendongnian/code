    public class ViewModel : INotifyPropertyChanged
    {
         public string SearchTerm 
         {
              get { return searchTerm; }
              set {
                    searchTerm = value;
                    SelectedSearchItem = SourceCollection.FirstOrDefault(foo => foo.Name.Contains(searchTerm));
              }
         }
         public Foo SelectedSearchItem 
         { 
               get { return selecedSearchItem; } 
               set {
                     selectedSearchItem = value;
                     // Raise PropertyChanged 
               }
         }
         public ObservableCollection<Foo> SourceCollection { get; set;}
    }
