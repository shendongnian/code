        List<\u003C\u003Ef__AnonymousType0<string>> source = Enumerable.ToList(Enumerable.Select(Enumerable.Range(0, 1000000), i =>
        {
          var local_0 = new
          {
            Name = Guid.NewGuid().ToString()
          };
          return local_0;
        }));
        source.Insert(999000, new
        {
          Name = diana
        });
        stopwatch.Restart();
        Enumerable.FirstOrDefault(source, c => c.Name == diana);
        stopwatch.Stop();
        Console.WriteLine("Diana was found in {0} ms with System.Linq.Enumerable.FirstOrDefault().", (object) stopwatch.ElapsedMilliseconds);
        stopwatch.Restart();
        source.Find(c => c.Name == diana);
        stopwatch.Stop();
        Console.WriteLine("Diana was found in {0} ms with System.Collections.Generic.List<T>.Find().", (object) stopwatch.ElapsedMilliseconds);
