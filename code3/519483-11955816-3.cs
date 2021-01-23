    public interface IStockInfo
    {
       string Name { get; }
       string Status { get; }
    }
    IStockInfo info = new StockInfo
                          {
                              Name = data[0] as string,
                              Status = s,
                              ...
                          }
