    public class Poco
    {
        public string ExtId { get; set; }
        public string Name { get; set; }
        public string[] Mobiles { get; set; }
    }
    var json = "[{\"ExtId\":\"2\",\"Name\":\"VIP sj�lland\",\"Mobiles\":[\"4533333333\",\"4544444444\"]";
    var dto = json.FromJson<Poco[]>();
    Assert.That(dto[0].ExtId, Is.EqualTo("2"));
    Assert.That(dto[0].Name, Is.EqualTo("VIP sj�lland"));
    Assert.That(dto[0].Mobiles, Is.Null);
