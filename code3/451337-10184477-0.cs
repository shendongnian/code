    public class House 
    {
         public string Color { get; set; }
         public string Material { get;set; }
         public string Window { get; set; }
    }
    public class ViewModel
    {
        public ObservableCollection<House> Houses { get; set; }
    }
