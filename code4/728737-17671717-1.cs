    public class LooneyTunes
    {
        public string Cat { get; set; }
        public string Mouse { get; set; }
    }
    var looneyTunes = JsonConvert.DeserializeObject<LooneyTunes>(json);
