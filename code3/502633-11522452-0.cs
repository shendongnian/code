    public class MyViewModel
    {
       public ObservableCollection<string> TheItems { get; set;}
       public string TheSelectedItem { get; set; }
       
       public MyViewModel()
       {
           TheItems = new ObservableCollection<string>();
           TheItems.Add("All");
           //Adding all the other value
       }
       public void SomeMethod()
       {
           if(TheSelectedItem=="All")
           {
              //Do whatever needs to be done 
           }
       }
    }
