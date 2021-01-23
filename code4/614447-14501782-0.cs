    interface IDriver<TUtillity> where TUtillity : IDriverUtility
    {
      IDriverIdentity DriverIdentity { get; }
      IDriverOperation Operation { get; }
      TUtillity Utility { get; }
    }
