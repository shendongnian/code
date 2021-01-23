        public ObservableCollection<ModalityType> ModalityTypes {
        get {
            return _studyRepository.ModalityTypes;
        }
        set
           {
              this.__studyRepository.ModalityTypes = value;
              RaisePropertyChanged("ModalityTypes");
           {
    }
