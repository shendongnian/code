    public class PeopleGroup {
        public string[] names { get; set; }
        public string nationality { get; set }
    }
    var myObject = JsonConvert.DeserializeObject<PeopleGroup>(x);
