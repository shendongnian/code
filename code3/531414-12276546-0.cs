            var source = Observable.Interval(TimeSpan.FromSeconds(0.1))
                                   .Take(10)
                                   .Publish()
                                   .RefCount();
            FirstOrLast(source, i => i == 5).Subscribe(Console.WriteLine); //5
            FirstOrLast(source, i => i == 11).Subscribe(Console.WriteLine); //9
