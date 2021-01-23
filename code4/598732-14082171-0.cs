    public NameViewModel : ViewModelBase
    {
        public NameModel Model
        { 
            get { /* get stuff */ }
            set { /* set stuff */ }
        } 
        // Default constructor creates its own new NameModel
        public NameViewModel()
        {
            this.Model = new NameModel();
        }
        // Constructor has a specific model dictated to it
        public NameViewModel(NameModel model)
        {
            this.Model = model;
        }
        //Model wrapper properties
        public String Name
        { 
            get { return Model.Name; }
            set { Model.Name = value; }
        }
    }
