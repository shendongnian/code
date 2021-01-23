    Parallel.ForEach(subscribers.ToArray(), subscriber =>
    {
        try
        {
            object ClientResult;
            ClientResult = publishMethodInfo.Invoke(
                subscriber.CallBackId, new object[] { ClData });
        }
        ...
    });
