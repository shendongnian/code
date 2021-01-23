    public class ApplicationObject
    {
        public List<ApplicationEntity> Application { get; set; }
    }
    ...
    var apps = JsonConvert.DeserializeObject<ApplicationObject>(jsonstring);
