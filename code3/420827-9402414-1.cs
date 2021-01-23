    public class Physician
    {
        private int _selectedClinicId;
        public Physician()
        {
            Name = "Overpaid consultant";
            Clinics = new ObservableCollection<Clinic>
                          {
                              new Clinic {Id = 0, Name = "Out Patients"},
                              new Clinic {Id = 1, Name = "ENT"},
                              new Clinic {Id = 2, Name = "GE"},
                          };
        }
        public string Name { get; set; }
        public IEnumerable<Clinic> Clinics { get; private set; }
        public int SelectedClinicId
        {
            get { return _selectedClinicId; }
            set
            {
                if (value != _selectedClinicId)
                {
                    Debug.WriteLine(string.Format("setting clinic to: {0}", value));
                    _selectedClinicId = value;
                }
            }
        }
    }
    public class Clinic
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
