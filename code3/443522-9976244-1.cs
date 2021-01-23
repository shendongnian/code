    dynamic jArr2 = JsonConvert.DeserializeObject(jsonstr);
    foreach (dynamic item in jArr2)
    {
        foreach (var subitem in item.TrailCoordinates)
        {
            Console.WriteLine(subitem.Longitude + " " + subitem.Latitude);
        }
    }
