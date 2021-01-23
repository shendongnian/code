    this.TagsChangeNotifier = _tags
        // for each tag value in tags...
        .Select(tag => 
        { 
            // Tick off every TimeSpan ts, then...
            return Observable.Interval(ts)
                // Say we've "ticked"
                .Do(tick => Console.WriteLine("It's time to tick!"))
                // Return the value "tag" (which remains constant...)
                .Select(_ => { return tag; })
                // Say what we see
                .Do(t => Console.WriteLine("I see a {0}!", t))
                // But only when it's different from the last one
                // (but we never change the value?)
                .DistinctUntilChanged(new DataTagComparer()); 
        })    
        // And mash them all together into one stream
        .Merge();
