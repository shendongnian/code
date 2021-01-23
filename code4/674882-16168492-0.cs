    public class FormInput
    {
        public string Surname { get; set; }
        public string ValidatedSurname
        {
            get
            {
                return string.IsNullOrWhiteSpace(Surname)
                       ? string.Empty
                       : Surname.Trim();
            }
        }
    }
