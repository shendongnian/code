    using (var enumerator = times.GetEnumerator())
    {
        DateTime time;
        while (enumerator.MoveNext()) 
        {
            time = enumerator.Current;
            // pre-condition code
            while (condition)
            {
                if (enumerator.MoveNext())
                {
                    time = enumerator.Current;
                    // condition code
                }
                else 
                {
                    condition = false;
                }
            }
            // post-condition code
        }
    }
