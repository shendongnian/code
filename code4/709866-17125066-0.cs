    using (IEnumerator<string> enumerator = request.Params.GetEnumerator())
    {
        while (enumerator.MoveNext())
        {
            string name = enumerator.Current;
 
            // Do something for each name
        }
    }
