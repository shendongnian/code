    public class SchemaDifferenceViewModel : BaseViewModel
    {
        private string firstSchemaToCompare;
    
        public string FirstSchemaToCompare
        {
            get { return firstSchemaToCompare; }
            set
            {
                firstSchemaToCompare = value;
                OnPropertyChanged("FirstSchemaToCompare");
            }
        }
