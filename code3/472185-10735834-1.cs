    var iter = source.GetEnumerator();
    using(iter as IDisposable) {
        if(iter.MoveNext()) {
            SomeType last = (SomeType) iter.Current;
            while(iter.MoveNext()) {
                // here, "last" is a non-final value; do something with "last"
                last = (SomeType) iter.Current;
            }
            // here, "last" is the FINAL one; do something else with "last"
        }
    }
    
