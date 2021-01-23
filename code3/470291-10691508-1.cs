    public class NameViewModel
    {
       private IList<string> _nameList = new List<string>();
       public IList<string> Names { get; set; }
       public string SelectedName { get; set; }
       public NameViewModel()
       {
           Names = GetAllNames();
           SelectedName = "A";
       }
    
       private IList<string> GetAllNames()
       {
           IList<string> names = new List<string>();
           names.Add("A");
           names.Add("B");
           names.Add("C");
           names.Add("D");
           return names;
       }
    }
