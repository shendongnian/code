    public class MyData : INotifyPropertyChanged
    {
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                Notify("Name");
            }
        }
        private bool nameSelected = false;
        public bool NameSelected
        {
            get { return nameSelected; }
            set
            {
                nameSelected = value;
                Notify("NameSelected");
            }
        }
      //... etc ...
    }
