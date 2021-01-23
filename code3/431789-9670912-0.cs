        public ObservableCollection<Movie> Items { get; set; }
        public MainViewModel()
        {
            XDocument xmlInfo = XDocument.Load(@"c:\temp\Xmlfile1.xml");
            var items = xmlInfo.Descendants("movie")
                            .Select(x => new Movie
                                             {
                                                 MovieName = x.Element("name").Value, 
                                                 Actors = x.Descendants("person").Where(p => p.Attribute("job").Value == "Actor").Select(a=>a.Attribute("name").Value).ToList(),
                                                 Directors = x.Descendants("person").Where(p => p.Attribute("job").Value == "Director").Select(a => a.Attribute("name").Value).ToList()
                                             });
            Items = new ObservableCollection<Movie>(items);
        }
