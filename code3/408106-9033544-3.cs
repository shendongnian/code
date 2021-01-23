    public class MyViewModel : ViewModelBase
    {
       //This property implements INPC and triggers notification on Set
       public string XamlViewData {get;set;}
       
       public ViewModel()
       {
          GetXamlFormData();  
       }
       //Gets the XAML Form from an external source (e.g. Database, File System)
       public void GetXamlFormData()
       {
           //Set the Xaml String property
           XamlViewData = //Logic to get XAML string from external source
       }
    }
