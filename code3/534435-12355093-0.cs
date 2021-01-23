     timer = new Timer( state => {
                       // simulate some work that takes ten seconds
                       Thread.Sleep( tickInterval * 10 );
                       // when the work is done, schedule the next callback in one second
                       timer.Change( tickInterval, Timeout.Infinite );
                   },
                   null,
                   tickInterval, // first callback in one second
                   Timeout.Infinite );
