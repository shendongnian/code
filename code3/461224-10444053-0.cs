    public interface IModel : INotifyPropertyChanged //just sample model
    {
        public string Title { get; set; }
    }
    
    public class ViewModel : NotificationObject //prism's ViewModel
    {
        private IModel model;
    
        //construct
        public ViewModel(IModel model)
        {
            this.model = model;
            this.model.PropertyChanged += new PropertyChangedEventHandler(model_PropertyChanged);
        }
    
        private void model_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Title")
            {
                //Do something if model has changed by external service.
                RaisePropertyChanged(e.PropertyName);
            }
        }
        //....more properties
    }
