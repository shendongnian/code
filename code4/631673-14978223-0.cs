    var random = new Random();
    var data =  List.Select(e => new myCustomItem 
    {
        Item = e , 
        TimeDistance = (e.StartTime.HasValue ? 
             (e.StartTime.Value - DateTime.Now).TotalMinutes :
              Enumerable.Range(-5000, 5000).OrderBy(i => random.NextDouble()).ToList().First()) 
    }).OrderBy(e => e.TimeDistance).ToList();
