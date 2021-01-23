    {
        var iter = sequence.GetEnumerator();
        using(iter as IDisposable)
        {
            while(iter.MoveNext())
            {   // note that before C# 5, "item" is declared *outside* the while
                var item = iter.Current;
                // some code
            }
        }
    }
