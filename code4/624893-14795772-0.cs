    public class someClass
    {
        ObservableCollection<someClass> Children { get; }
    
        long NumOfSelectedChildren { get; set; }
        int UpdateNumOfSelectedChildren()
        {
           return NumOfSelectedChildren =
               Children.Sum(x => 1 + x.UpdateNumOfSelectedChildren());
        }
    }
