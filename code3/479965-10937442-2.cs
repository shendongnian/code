    public IList<Alert> GetAlerts()
    {
        return (xmlDoc1.Descendant("Notifications").Elements("Alerts").Select(s => 
            new Dictionary<string,string>
            {
                { "Max", s.Element("Max").Value },
                { "Med", s.Element("Med").Value },
                { "Min", s.Element("Min").Value }
            }).ToList();
    }
