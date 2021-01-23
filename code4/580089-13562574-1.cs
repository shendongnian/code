    class Student : PropertyChangedBase
    {
        public String StudentFirstName
        {
            get { return model.StudentFirstName; }
            set 
              { 
                model.StudentFirstName = value;
                this.OnPropertyChanged("StudentFirstName"); 
              }
        }
        public String StudentLastName
        {
           get { return model.StudentLastName; }
           set 
              { 
                 model.StudentLastName = value;
                 this.OnPropertyChanged("StudentLastName");
              }
        } 
    }
