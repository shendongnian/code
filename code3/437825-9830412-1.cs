    public class MountainsViewModel
    {
        public MountainsViewModel()
        {
            Mountains = new ObservableCollection<Mountain>
                            {
                                new Mountain
                                    {
                                        Name = "Whistler",
                                        Lifts = new ObservableCollection<Lift>
                                                    {
                                                        new Lift
                                                            {
                                                                Name = "Big Red",
                                                                Runs = new ObservableCollection<string>
                                                                           {
                                                                               "Headwall",
                                                                               "Fisheye",
                                                                               "Jimmy's"
                                                                           }
                                                            },
                                                        new Lift
                                                            {
                                                                Name = "Garbanzo",
                                                                Runs = new ObservableCollection<string>
                                                                           {
                                                                               "Headwall1",
                                                                               "Fisheye1",
                                                                               "Jimmy's1"
                                                                           }
                                                            },
                                                        new Lift {Name = "Orange"},
                                                    }
                                    },
                                new Mountain
                                    {
                                        Name = "Stevens",
                                        Lifts = new ObservableCollection<Lift>
                                                    {
                                                        new Lift {Name = "One"},
                                                        new Lift {Name = "Two"},
                                                        new Lift {Name = "Three"},
                                                    }
                                    },
                                new Mountain {Name = "Crystal"},
                            };
        }
        public string Name { get; set; }
        private string _selectedRun;
        public string SelectedRun
        {
            get { return _selectedRun; }
            set
            {
                Debug.WriteLine(value);
                _selectedRun = value;
            }
        }
        public ObservableCollection<Mountain> Mountains { get; set; }
    }
    public class Mountain
    {
        public string Name { get; set; }
        public ObservableCollection<Lift> Lifts { get; set; }
    }
    public class Lift
    {
        public string Name { get; set; }
        public ObservableCollection<string> Runs { get; set; }
    }
