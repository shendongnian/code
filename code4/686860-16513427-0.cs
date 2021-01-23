    class Program
    {
        static void Main(string[] args)
        {
            string json = @"{""stations"":[{""Name"":""WXRT""},{""Name"":""WGN""}]}";
            Foo foo = JsonConvert.DeserializeObject<Foo>(json);
            foreach (StationDto dto in foo.Stations)
            {
                Console.WriteLine(dto.Name);
            }
        }
    }
    class StationDto
    {
        public string Name { get; set; }
    }
    class Foo
    {
        private ObservableCollection<StationDto> stations;
        [JsonProperty(PropertyName = "stations")]
        public ObservableCollection<StationDto> Stations
        {
            get { return this.stations; }
            set 
            { 
                this.stations = value;
                RaisePropertyChanged(() => Stations);
            }
        }
        private void RaisePropertyChanged(Func<ObservableCollection<StationDto>> coll)
        {
        }
    }
