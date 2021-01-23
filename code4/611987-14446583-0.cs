    public class SomeObject
    {
      public string fname { get; set; }
      public override ToString()
      {
        return "fname = " + fname;
      }
    }
    var data = from item in doc.Descendants("users")
                       where item.Element("user").Element("username").Value == "SomeUser"
                       select new SomeObject { fname = item.Element("user").Element("firstname").Value }
