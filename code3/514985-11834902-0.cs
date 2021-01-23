    using (var it = ndo.GetEnumerator())
        while (it.MoveNext())
        {                
            //// Pass the variable it as parameter
            SomeFunction(it.Current);
        }
