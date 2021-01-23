    public class Alert
    {
        public string Max { get; set; }
        public string Med { get; set; }
        public string Min { get; set; }
    }
    public IList<Alert> GetAlerts()
    {
        return (xmlDoc1.Descendant("Notifications").Elements("Alerts").Select(s => 
            new Alert
            {
                Max = s.Element("Max").Value,
                Med = s.Element("Med").Value,
                Min = s.Element("Min").Value
            }).ToList();
    }
