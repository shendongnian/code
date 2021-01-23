    partial class Player : IDataErrorInfo
    {
        private delegate string Validation(string value);
        private Dictionary<string, Validation> columnValidations;
        public List<string> Errors;
        public Player()
        {
            columnValidations = new Dictionary<string, Validation>();
            columnValidations["Firstname"] = delegate (string value) {
                return String.IsNullOrWhiteSpace(Firstname) ? "Geef een voornaam in" : null;
            }; // Add the others...
            errors = new List<string>();
        }
        public bool CanSave { get { return Errors.Count == 0; } }
        public string this[string columnName]
        {
            get { return this.GetProperty(columnName); } 
            set
            { 
                var error = columnValidations[columnName](value);
                if (String.IsNullOrWhiteSpace(error))
                    errors.Add(error);
                else
                    this.SetProperty(columnName, value);
            }
        }
    }
