    public class MyViewModel
    {
       public ObservableCollection<MyModel> Images { get; set; }
       public ICommand ButtonClicked { get; set; }
       ... Logic to populate the images
    }
