    using System.Xml.Linq;
    ...
    var root = XDocument.Parse(xmlString).Root;
    var cars = root
        .ToAll("Car")
        .Select(car => new
        {
            Name = car.ToFirst("Name").Value,
            Speed = car.ToAll("Speed").Any() ? car.ToFirst("Speed").Value : null,
            Color = car.ToFirst("Color").Value,
            Engine = car.ToFirst("Engine").Value,
            Year = int.Parse(car.ToFirst("Year").Value)
        })
        .ToList();
