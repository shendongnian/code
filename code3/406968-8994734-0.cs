    //ViewModel 
    public class MyViewModel : INotifyPropertyChanged
    {
         private string textBoxText = string.Empty;
         public string TextBoxText 
         {
            get {return textBoxText;}
            set {
               textBoxText = value;
               OnPropertyChanged("TextBoxText "..);
            }
         }
    }
