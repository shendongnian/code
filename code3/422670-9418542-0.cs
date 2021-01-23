    interface IInterface { Id { get; } }
    class Class : IInterface
    {
      public static Id { get { return 1; } }
      public Id { get { return Class.Id; } }
    }
