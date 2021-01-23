    public class NotificationHelper : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private readonly ISynchronizeInvoke invokeDelegate;
        private readonly Entity entity;
        public NotificationHelper(ISynchronizeInvoke invokeDelegate, Entity entity)
        {
           this.invokeDelegate = invokeDelegate;
           this.entity = entity;
           entity.PropertyChanged += OnPropertyChanged;
        }
        public string Name
        {
           get { return entity.Name; }
        }
        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
            {
               if (invokeDelegate.InvokeRequired)
               {
                   invokeDelegate.Invoke(new PropertyChangedEventHandler(OnPropertyChanged),
                                         new[] { sender, e });
                   return;
               }
               PropertyChanged(this, e);
            }
         }
     }
