    Image etherImage = new Image();
    etherImage .Attributes["style"] = "display:inline-Block; overflow:hidden;";
    etherImage .ImageUrl = "/images/webdataentry/Off.png"; 
    Image orImage = new Image(); // New Object! thats the key.
    orImage .Attributes["style"] = "display:inline-Block; overflow:hidden;";
    orImage .ImageUrl = "/images/webdataentry/Off.png"; 
    orImagePanel.Controls.Add(orImage);
    eitherImagePanel.Controls.Add(etherImage);
