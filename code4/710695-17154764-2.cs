    using (var alphaEnumerator = alpha.GetEnumerator())
    using (var betaEnumerator = beta.GetEnumerator())
    {
        while (alphaEnumerator.MoveNext() && betaEnumerator.MoveNext())
        {
            var alphaItem = alphaEnumerator.Current;
            var betaItem = betaEnumerator.Current;
            // Do something
        }
    }
