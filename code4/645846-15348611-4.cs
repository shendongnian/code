    public class MyObjectViewModel : INotifyPropertyChanged
    {
        private myObject obj;
        
        public Image Image
        {
            get;
            private set;
        }
        public MyObjectViewModel(myObject obj)
        {
            this.obj = obj;
            this.Image = obj.getImage();
        }
        public void SomethingThatMakesImageChange()
        {
            this.Image = obj.getImage();
            this.RaisePropertyChanged("Image");
        }
        // ... insert suitable INPC implementation ...
    }
