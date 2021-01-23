    public class ClsdataSourceCollection : ObservableCollection<Clsdatasource>
    {
        private const string FileName = "MyData.xml";
        private readonly XmlSerializer _serializer = new XmlSerializer(typeof(List<Clsdatasource>));
        public void LoadData(Action onCompleted)
        {
            using (StreamReader sr = new StreamReader(FileName))
            {
                var s = _serializer.Deserialize(sr) as List<Clsdatasource>;
                if (s != null)
                {
                    Clear();
                    s.ForEach(Add);
                }
            }
            onCompleted();
        }
        public void SaveData(Action onCompleted)
        {
            using (StreamWriter sw = new StreamWriter(FileName))
            {
                List<Clsdatasource> tosave = new List<Clsdatasource>();
                tosave.AddRange(this);
                _serializer.Serialize(sw, tosave);
            }
            onCompleted();
        }
    }
