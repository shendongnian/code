    public interface IPrice
    {
        string Id { get; set; }
        DateTime EntryDate { get; set; }
        decimal Value { get; set; }
        int ExchangeTypeId { get; set; }
    }
    public interface IUnitOfWork<T>
        where T: IPrice
    {
        T GetLatest(int exchangeTypeId);
        void Add(T price);
        void Commit();
    }
    public interface IUnitOfWorkFactory
    {
        void Register<T>() where T: IPrice;
        IUnitOfWork<T> Get<T>() where T: IPrice;
    }
    public void AddPrice<T>(int exchangeTypeId, decimal price)
        where T: IPrice, new()
    {
        IUnitOfWork<T> unitOfWork = _unitOfWorkFactory.Get<T>();
        IPrice lastPriceValue = unitOfWork.GetLatest(exchangeTypeId);
        
        if (lastPriceValue == null || lastPriceValue.Value != price)
        {
            unitOfWork.Add(
                new T
                {
                    Id = Guid.NewGuid().ToString(),
                    EntryDate = DateTime.Now,
                    Value = price,
                    ExchangeTypeId = exchangeTypeId,
                });
        }
        else
        {
            lastPriceValue.EntryDate = DateTime.Now;
        }
        
        unitOfWork.Commit();
    }
