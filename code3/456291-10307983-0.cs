    public class ViewModel : INotifyPropertyChanged
    {
          public MyEnum EnumValue 
          { 
               get { return enumValue; } 
               set { 
                     enumValue = value;
                     AreControlsEnabled = enumValue == MyEnum.SomeValue;
               }
          }
          public bool AreControlsEnabled 
          {
               get { return areControlsEnabled; }
               set {
                     areControlsEnabled = value;
                     if (PropertyChanged != null)
                         PropertyChanged(this, new PropertyChangedEventArg("AreControlsEnabled");
                }
          }
          public event PropertyChangedEventHandler PropertyChanged;
    }
