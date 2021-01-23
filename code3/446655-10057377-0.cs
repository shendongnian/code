     public class BindableSettings : INotifyPropertyChanged
        {
             public string Command01
             {
                    get { return Properties.Settings.Default.cmd01; }
                    set 
                    {
                          if (Properties.Settings.Default.cmd01 == value)
                               return;
                          
                          NotifyPropertyChanged("Command01");
                    }
             }
        
             public void NotifyPropertyChanged(string prop)
             {
                 Properties.Settings.Default.Save();
                 //Raise INPC event here...
             }
        
        }
