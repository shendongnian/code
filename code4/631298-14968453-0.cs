    using (var iterator = results.GetEnumerator())
    {
        if (!iterator.MoveNext())
        {
            // Throw some appropriate exception here.
        }
        Result firstResult = iterator.Current;
        DoAVeryImportOperationWithFirstResult(firstResult);
        Console.WriteLine(String.Format("This is the {0} result.", resultIndex++));
        yield return firstResult;
        while (iterator.MoveNext())
        {
            Result result = iterator.Current;
            Console.WriteLine(String.Format("This is the {0} result.", resultIndex++));
            yield return result;
        }
    }
