        /// <summary>
        /// structureField
        /// </summary>
        private string structureField;
        private string lableText;
        /// <summary>
        /// StructureField        
        /// </summary>
        public string StructureField
        {
            get { return structureField; }
            set
            {
                structureField= value;
                OnPropertyChanged("StructureField");
            }
        }
        /// <summary>
        /// StructureField        
        /// </summary>
        public string LableText
        {
            get { return lableText; }
            set
            {
                lableText= value;
                OnPropertyChanged("LableText");
            }
        }
    }
  
  
    /// <summary>
    /// DataGridRowViewModel
    /// </summary>
    public class MainViewModel:BaseViewModel
    {
        /// <summary>
        /// structureField
        /// </summary>
        private ObservableCollection<DataGridRowViewModel> rowCollection; 
        //Make Property with INotifyPropertyChanged
        /// <summary>
        ///   Default Constructor
        /// </summary>
        public MainViewModel()
        {
              RowCollection = new ObservableCollection<DataGridRowViewModel>();
              FillCollectionWithStructureFields();
        }
        
        private void FillCollectionWithStructureFields()
        {
              //Fill Add New Instances of DataGridRowViewModel with required Label  
              // and Structure Filead Values
        }
    }
