    XNamespace ns = "http://schemas.microsoft.com/search/local/ws/rest/v1";
    var boundingBox = document
                    .Descendants(ns + "Response")
                    .Descendants(ns + "ResourceSets")
                    .Descendants(ns + "ResourceSet")
                    .Descendants(ns + "Resources")
                    .Descendants(ns + "Location")
                    .Descendants(ns + "BoundingBox");
    if (boundingBox != null)
    {
        Console.WriteLine(boundingBox.Descendants(ns + "SouthLatitude").First().Value);
        Console.WriteLine(boundingBox.Descendants(ns + "NorthLatitude").First().Value);
        Console.WriteLine(boundingBox.Descendants(ns + "EastLongitude").First().Value);
        Console.WriteLine(boundingBox.Descendants(ns + "WestLongitude").First().Value);
    }        
