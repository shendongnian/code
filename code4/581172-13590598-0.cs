    var random = new Random();
    var startDateTime = new DateTime(2000, 1, 1, 7, 0, 0, 0);
    var maxDuration = TimeSpan.FromHours(4);
    var values = Enumerable.Range(0, 100)
        .Select(x => {
            var duration = random.Next(0, (int)maxDuration.TotalMinutes);
            return startDateTime.AddMinutes(duration).ToString("HH:mm");
        })
        .ToList();
        
    values = values.Distinct().ToList();
    Console.WriteLine("{0} values found. Min: {1}, Max: {2}", values.Count, values.Min(), values.Max());
