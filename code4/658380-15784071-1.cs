            var system =
            FeedbackSystem((IObservable<double> acceleration, out IObservable<double> velocity) =>
            {
                //Time axis: moves forward every 0.1s
                double t = 0.1; var timeaxis = Observable.Interval(TimeSpan.FromSeconds(t));
                
                velocity = acceleration.Sample(timeaxis)                //move in time
                                       .Scan((u, a) => u + a * t)   //u' = u + at
                                       .Select(u => u + new Random().Next(10))  //some variations in speed
                                       .Publish().RefCount();                   //avoid recalculation
                                
                //negative feedback
                var feedback = velocity.Select(u => 0.5 * (100 - u));
                return feedback.Select(a => Math.Min(a, 15.0))  //new limited acceleration
                               .StartWith(0);                   //initial value          
            });
            system.Subscribe(Console.WriteLine);
