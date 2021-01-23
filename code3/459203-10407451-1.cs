    var sample = new List<double>()
                      {
                         96,
                         95,
                         112,
                         111,
                         119,
                         104,
                         143,
                         96,
                         95,
                         104,
                         120,
                         112
                      };
    
    var min = sample.Min();
    sample = sample.Select(it => it - min).ToList();
    
    var lambda = 1d / sample.Average();
    
    var random = new Random();
    var result = new List<double>();
    for (var i = 0; i < 100; i++)
    {
       var simulated = min - Math.Log(random.NextDouble()) / lambda;
       result.Add(simulated);
       Console.WriteLine(simulated);
    }
