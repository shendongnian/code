    public class Foo: INotifyPropertyChanged
    {
        
      public event PropertyChangedEventHandler PropertyChanged;
      private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
      {
          if (PropertyChanged != null)
          {
           if (mainForm.InvokeRequired)
           {
               mainForm.Invoke(() =>
               {
                   PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
               });
            }
            else
            {
               PropertyChanged(this, new PropertyChangedEventArgs(propertyName)); 
            }
          }
      } 
    }
