    [XmlRoot("Mitarbeiterstatistik")]
    public class Mitarbeiterstatistik
    {
      private List<Mitarbeiter> list = new List<Mitarbeiter>();
      [XmlElement("Mitarbeiter")]
      public List<Mitarbeiter> List {get; set;}     
    }
