    using(var iter = source.GetEnumerator()) {
        if(iter.MoveNext()) {
            T last = iter.Current;
            while(iter.MoveNext()) {
                // here, "last" is a non-final value; do something with "last"
                last = iter.Current;
            }
            // here, "last" is the FINAL one; do something else with "last"
        }
    }
