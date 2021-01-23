    var hotels = JsonConvert.DeserializeObject<List<Hotel>>(e.Result);
---
    public class Hotel
    {
        public int hotId;
        public string Name;
        public double latitude;
        public double longitude;
    }
