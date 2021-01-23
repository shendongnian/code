    string json = your__json__string
    //PreProcess
    var jobj = JObject.Parse(json);
    foreach (var j in jobj["ObjectList"])
    {
        if (!(j["RoomImage"] is JArray))
        {
            j["RoomImage"] = new JArray(j["RoomImage"]);
        }
    }
    var obj = JsonConvert.DeserializeObject<RootObject>(jobj.ToString());
---
    public class InternalOnly
    {
        public string RoomId { get; set; }
        public string FloorId { get; set; }
    }
    public class RoomImage
    {
        public string ImagePath { get; set; }
        public string ImageType { get; set; }
        public string CreatedDate { get; set; }
        public string CreatedId { get; set; }
        public string LastUpdateDate { get; set; }
        public string LastUpdateId { get; set; }
    }
    public class ObjectList
    {
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public string RoomListEmailAddress { get; set; }
        public string MinimumXCoordinateInMap { get; set; }
        public string MinimumYCoordinateInMap { get; set; }
        public string MaximumXCoordinateInMap { get; set; }
        public string MaximumYCoordinateInMap { get; set; }
        public string RoomCapacity { get; set; }
        public RoomImage[] RoomImage { get; set; }
        public string FloorName { get; set; }
        public string CreatedDate { get; set; }
        public string CreatedId { get; set; }
        public string LastUpdatedDate { get; set; }
        public string LastUpdatedId { get; set; }
        public string IsRestrictedRoom { get; set; }
        public InternalOnly InternalOnly { get; set; }
        public object Equipment { get; set; }
    }
    public class RootObject
    {
        public List<ObjectList> ObjectList { get; set; }
    }
