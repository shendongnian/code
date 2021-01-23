    [XmlRoot("CarList")]
    public class CarList
    {
      [XmlAttribute("Name")]
      public string Name  { get; set; }
      
      [XmlElement("Cars")]
      [XmlElement("BWM", typeof(BMW))]
      [XmlElement("Acura", typeof(Acura))]
      //[XmlArrayItem("Honda", typeof(Honda))]
      public List<Car> Cars  { get; set; }
      
      public static CarList Load(string xmlFile)
      {
        CarList carList = new CarList();
        XmlSerializer s = new XmlSerializer(typeof(CarList));
        TextReader r = new StreamReader(xmlFile);
        carList = (CarList)s.Deserialize(r);
        r.Close();
        return carList;
      }
    
      public static void Save(CarList carList, string fullFilePath)
      {
        XmlSerializer s = new XmlSerializer(typeof(CarList));
        TextWriter w = new StreamWriter(fullFilePath);
    
        // use empty namespace to remove namespace declaration
        XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
        ns.Add("", "");
    
        s.Serialize(w, carList, ns);
        w.Close();
      }
    }
