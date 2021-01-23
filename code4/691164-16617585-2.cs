    PlayerStats stats;
    using (var fileStream = new System.IO.FileStream("Sample.XML", System.IO.FileMode.Open))
    {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(PlayerStats));
        stats = (PlayerStats)xmlSerializer.Deserialize(fileStream);
    }
    var player = stats.Players.Where(p => p.Name == "Jack").FirstOrDefault();
    if (player != null)
    {
        // Update the record
        player.WinCount = player.WinCount + 1;
        player.PlayCount = player.PlayCount + 1;
        // Save back to file
        using (var fileStream = new System.IO.FileStream("Sample.XML", System.IO.FileMode.Open))
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(PlayerStats));
            xmlSerializer.Serialize(fileStream, stats);
        }
    }
