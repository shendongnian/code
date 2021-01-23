    public class Foo: INotifyPropertyChanged
    {
        
      public event PropertyChangedEventHandler PropertyChanged;
      private void NotifyPropertyChanged(String propertyName = "")
      {
          if (PropertyChanged != null)
          {
           if (mainForm.InvokeRequired)
           {
               mainForm.Invoke((MethodInvoker) delegate
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
