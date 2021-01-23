    protected override void SaveApsXml(System.Xml.XmlNode node)
    {
        base.SaveApsXml(node);            
        node.AppendNewChild("EventTime").SetElementText(this.EventTime.ToString(ApsMessage.DateTimeFormat));
        var track = node.AppendNewChild("Track");
        track.SetAttribute("name", this.Track);
        this.SequenceCar.SaveApsXml(track.AppendNewChild("Car"));
    }
