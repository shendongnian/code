    public class LVData
        {
            public string Name { get; set; }
            public string YoungPic { get; set; }
            public string MediumPic { get; set; }
            public string AdultPic { get; set; }
            public byte Terrain { get; set; }
        }
        public class WindowViewModel : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
            //called when a property is changed
            protected void RaisePropertyChanged(string PropertyName)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
                }
            }
    
            private ObservableCollection<LVData> _personList = new ObservableCollection<LVData>();
            public ObservableCollection<LVData> lsvData
            {
                get { return _personList; }
                set { _personList = value; RaisePropertyChanged("lsvData"); }
            }
    
            public void PopulateDataFromXML()
            {
                XDocument loaded = XDocument.Load(@"c:\documents and settings\bjasti\my documents\visual studio 2010\Projects\lvs\lvs\data.xml");
    
                var Persons = from x in loaded.Descendants("Person")
                              select new
                              {
                                  Name = x.Descendants("Name").First().Value,
                                  YoungPic = x.Descendants("YoungPic").First().Value,
                                  MediumPic = x.Descendants("MediumPic").First().Value,
                                  AdultPic = x.Descendants("AdultPic").First().Value,
                                  Terrain = x.Descendants("Terrain").First().Value
                              };
                foreach (var _person in Persons)
                {
                    _personList.Add(new LVData { Name = _person.Name, YoungPic = _person.YoungPic, MediumPic = _person.MediumPic, AdultPic = _person.AdultPic, Terrain = Convert.ToByte(_person.Terrain) });
                }
    
                RaisePropertyChanged("lsvData");
            }
    
        }
