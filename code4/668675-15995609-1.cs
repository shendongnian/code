         var det = new Destinations();
         det.Details = new List<DestinationDetails>();
          det.Details.Add(new DestinationDetails() { Destination = "CA" });
          det.Details.Add(new DestinationDetails() { Destination = "NJ" });
          ...
          ...
         var details = new DestinationDetails();
         details.Destination = string.Join(",",det.Details.Select(x => x.Destination).ToArray() );
