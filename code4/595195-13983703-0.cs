    public delegate TResult GetOrAdd<TResult>(string key, Queue<GetOrAdd<TResult>> generatorChain);
    static T ExecuteChain<T>(string key, params GetOrAdd<T>[] generators)
    {
        var queue = new Queue<GetOrAdd<T>>(generators.Skip(1));
        return generators.First()(key, queue);
    }
    static int A(string key, Queue<GetOrAdd<int>> generatorChain)
    {
        var newKey = key.ToUpper();
        //You can perform checks on the queue
        //i.e. if it's empty, throw an exception
        var tempResult = generatorChain.Dequeue()(newKey, generatorChain);
        return tempResult*2;
    }
    static int B(string key, Queue<GetOrAdd<int>> generatorChain)
    {
        var newKey = key.Insert(0, "My string is: ");
        var tempResult = generatorChain.Dequeue()(newKey, generatorChain);
        return tempResult + 1;
    }
    static int ValFactory(string key, Queue<GetOrAdd<int>> generatorChain)
    {
        //Instead of defining another delegate, we just don't use the queue
        //You can still run your checks (i.e. throw exception if not empty)
        return key.GetHashCode();
    }
