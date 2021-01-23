    public class ApplicationObject
    {
        public List<ApplicationEntity> Applications { get; set; }
    }
    ...
    var apps = JsonConvert.DeserializeObject<ApplicationObject>(jsonstring);
