    public static Task<double> GetTask()
    {
        return new Task<double>(
            () => Task.Factory.StartNew(() => 10)
                      .ContinueWith(
                          i =>
                          {
                              return i.Result + 2;
                          })
                      .ContinueWith(
                          i =>
                          {
                              return (double)i.Result;
                          }).Result);
    }
