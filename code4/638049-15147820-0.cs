    var items = 
       File.ReadAllLines(filename)
           .Select(line => line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                               .Select(Int32.Parse)
                               .ToArray())
           .Select(values => new {
                TopSpeed = values[0],
                AverageSpeed = values[1],
                Cadence = values[2],
                Altitude = values[3],
                HeartRate = values[4],
                Power = values[5]
           });
