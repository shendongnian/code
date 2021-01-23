    public Model SelectedModel {
            get { return selectedModel; }
            set { 
                selectedModel = value; 
                NotifyChanged("SelectedModel");   
                NotifyChanged("ID");
                NotifyChanged("Name");
            }
        }
