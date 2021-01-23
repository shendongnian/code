    [Serializable()]
    public class Defaults
    {
        public string Description { get; set; }
        public double Tolerance { get; set; }
        public string Units { get; set; }
     }
    internal class FormDefaults
    {
    public void LoadSettings()
        {
          string kfileString = @"C:\Default_Settings.xml";
          var q = from el in XElement.Load(kfileString).Elements()
                    select new FormDefault()
                    {
                        Description = el.Element("InstrumentDescription").Value,
                        Tolerance = Double.Parse(el.Element("InstrumentMassTolerance").Value),
                        Units = el.Element("InstrumentMassUnits").Value,
                       
                    };
            }
        }
    }
    
