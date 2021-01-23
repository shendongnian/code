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
    
    var random = new Random();
    var size = sample.Count();
    for (var i = 0; i < 100; i++)
    {
       Console.WriteLine(sample[random.Next(0, size)]);
    }
